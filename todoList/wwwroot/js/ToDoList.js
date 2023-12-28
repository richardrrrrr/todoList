document.addEventListener("DOMContentLoaded", function () {
    fetchToDoLists();
    
});


function fetchToDoLists() {

    fetch('/api/todolist')
        .then(response => response.json())
        .then(data => displayToDoList(data))
        .catch(error => console.error('Unable to retrieve todolists.', error));

}


function displayToDoList(data) {
    const tableBody = document.getElementById('todoListTableBody');
    tableBody.innerHTML = '';

    data.forEach(item => {
        
        let row = `<tr>
            <td><input type="checkbox" name="selectedCategory" ${item.isComplete ? 'checked' : ''} /></td>
            <td>${item.name}</td>
            <td>${item.priority}</td>
            <td>${item.created_at}</td>
            <td>${item.complete_at}</td>
            <td>
                <div class="w-10 btn-group" role="group">
                    <button class="btn btn-primary mx-2" data-id="${item.id}" onclick="updateTodolist(this)">Edit</button>
                    <button class="btn btn-danger mx-2" onclick="deleteTodolist(this.getAttribute('data-id'))" data-id="${item.id}">Delete</button>
                </div>
            </td>
        </tr>`;
        tableBody.innerHTML += row;
    });


    document.querySelectorAll('input[name="selectedCategory"]').forEach(checkbox => {
        checkbox.addEventListener('change', function () {
            if (this.checked) {

                this.disabled = true;
            }
        });
    });
}



function createToDoList() {
    const nameInput = document.getElementById('recipient-name');
    const priorityInput = document.getElementById('message-text');
    const currentDate = new Date();

    const data = {
        Account_ID: 2,
        Name: nameInput.value,
        Priority: parseInt(priorityInput.value),
        Created_at: currentDate.toISOString(),
        Complete_at: null,
        IsComplete: false,
    };

    fetch('/api/todolist', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('網路請求錯誤');
            }
            return response.json();
        })
        .then(addedItem => {
            console.log('添加成功:', addedItem);
            fetchToDoLists();
            alert('TodoList build success！');
        })
        .catch(error => {
            console.error('創建 TodoList 項目失敗:', error);
        });
}
postButton = document.getElementById('sendButton');
postButton.addEventListener('click', createToDoList);


function deleteTodolist(id) {
    
    fetch(`/api/todolist/${id}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('網路請求錯誤');
            }
            fetchToDoLists(); 
        })
        .catch(error => console.error('刪除 TodoList 項目失敗:', error));
}


function updateTodolist(button) {
    const id = button.getAttribute('data-id');
   

    // 填充模態窗口的數據
    const nameInput = document.getElementById('recipient-name');
    const priorityInput = document.getElementById('message-text');
    nameInput.value = nameInput;
    priorityInput.value = priorityInput;

    // 打開模態窗口
    const modal = new bootstrap.Modal(document.getElementById('exampleModal'));
    modal.show();

    // 保存按鈕的事件處理器
    const saveButton = document.getElementById('sendButton');
    saveButton.onclick = function () {
        const updatedData = {
            Name: nameInput.value,
            Priority: parseInt(priorityInput.value),
           
        };

        fetch(`/api/todolist/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(updatedData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('網路請求錯誤');
                }
                return response.json();
            })
            .then(updatedItem => {
                console.log('更新成功:', updatedItem);
                fetchToDoLists(); 
                modal.hide(); 
            })
            .catch(error => {
                console.error('更新 TodoList 項目失敗:', error);
            });
    };




}




