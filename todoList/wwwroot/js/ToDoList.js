document.addEventListener("DOMContentLoaded", function () {
    fetchToDoLists();
});


function fetchToDoLists() {
    fetch('/api/todolist')
        .then(Response => Response.json())
        .then(data => displayToDoList(data))
        .catch(error => console.error('Unable to retrieve todolists.', error));
}


function displayToDoList(data) {
    const tableBody = document.getElementById('todoListTableBody');
    tableBody.innerHTML = '';

    data.forEach(item => {
        let row = `<tr>
            <td><input type="checkbox" name="selectedCategory" ${item.isChecked ? 'checked' : ''} /></td>
            <td>${item.name}</td>
            <td>${item.displayOrder}</td>
            <td>${item.startTime}</td>
            <td>${item.completeTime}</td>
            <td>
                <div class="w-10 btn-group" role="group">
                    <button class="btn btn-primary mx-2" onclick="updateTodolist(${item.id})">Edit</button>
                    <button class="btn btn-danger mx-2" onclick="deleteTodolist(${item.id})">Delete</button>
                </div>
            </td>
        </tr>`;
        tableBody.innerHTML += row;
    });
}


function creatToDoList() {

}