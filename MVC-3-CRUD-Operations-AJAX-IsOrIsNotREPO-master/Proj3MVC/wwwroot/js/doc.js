$(document).ready(function () {
    getEmpData();
    $('#btn1').click(function () {
        $('#exampleModal').modal('show');
        $('#exampleModalLabel').text("Add Emp");
        $('#savebtn').show();
        $('#updbtn').hide();
        $('#eid').hide();
    });

    $('#closebtn').click(function () {
        $('#exampleModal').modal('hide');
    });

    function clear() {
        $('#Name').val("");
        $('#Dept').val("");
        $('#Salary').val("");
    }

    $('#savebtn').click(function () {
        //METHOD 1
        var obj = {
            name: $('#Name').val(),
            dept: $('#Dept').val(),
            salary: $('#Salary').val()
        }
        //or METTHOD 2
        //var obj =$('#myform').serialize();
        //we neet to add name="" inside the form div for this method, and add id="" in form tag

        $.ajax({
            url: '/Ajax/AddEmp',
            contentType: 'application/x-www-form-urlencoded;charset=utf8;',
            type: 'Post',
            datatype: 'json',
            data: obj,
            success: function () {
                alert("Emp added successfully");
                clear();
                $('#exampleModal').modal('hide');
            },

            error: function () {
                alert("Something went wrong");
            }
        });
    });
    $('#updbtn').click(function () {
        //METHOD 1
        var obj = {
            name: $('#Name').val(),
            dept: $('#Dept').val(),
            salary: $('#Salary').val()
        }
        //or METTHOD 2
        //var obj =$('#myform').serialize();
        //we neet to add name="" inside the form div for this method, and add id="" in form tag
        $.ajax({
            url: '/Ajax/EditEmp',
            contentType: 'application/x-www-form-urlencoded;charset=utf8;',
            type: 'Post',
            datatype: 'json',
            data: obj,
            success: function () {
                alert("Emp updated successfully");
                clear();
                $('#exampleModal').modal('hide');
            },

            error: function () {
                alert("Something went wrong");
            }
        });
    });


});
//gridview in .net core
function getEmpData() {
    $.ajax({
        url: '/Ajax/GetEmp',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf8;',
        success: function (result, status, xhr) {
            obj = '';
            $.each(result, function (index, item) {
                obj += "<tr>";
                obj += "<td>" + item.id + "</td>";
                obj += "<td>" + item.name + "</td>";
                obj += "<td>" + item.dept + "</td>";
                obj += "<td>" + item.salary + "</td>";
                obj += "<td><input type='button' class='btn btn-sm btn-danger' onclick='delEmp(" + item.id + ")' value='Delete'> <input type='button' class='btn btn-sm btn-success' onclick='editEmp(" + item.id + ")' value='Edit'></td>";
                obj += "</tr>";
            });
            $("#tabledata").html(obj);
            $('#eid').hide();
        },
        error: function () {
            alert("Data not found!");
        }
    });
}

function SearchEmpData() {
    var sdata = $('#Search').val();
    $.ajax({
        url: '/Ajax/SearchEmp?sdata' = sdata,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf8;',
        success: function (result, status, xhr) {
            obj = '';
            $.each(result, function (index, item) {
                obj += "<tr>";
                obj += "<td>" + item.id + "</td>";
                obj += "<td>" + item.name + "</td>";
                obj += "<td>" + item.dept + "</td>";
                obj += "<td>" + item.salary + "</td>";
                obj += "<td><input type='button' class='btn btn-sm btn-danger' onclick='delEmp(" + item.id + ")' value='Delete'> <input type='button' class='btn btn-sm btn-success' onclick='editEmp(" + item.id + ")' value='Edit'></td>";
                obj += "</tr>";
            });
            $("#tabledata").html(obj);
            $('#eid').hide();
        },
        error: function () {
            alert("Data not found!");
        }
    });
}

function delEmp(id) {
    if (confirm("Do you want to delete this record?")) {
        $.ajax({
            url: '/Ajax/DeleteEmp?eid=' + id,
            success: function () {
                alert("Emp Deleted Successfully!");
                getEmpData();
            },
            error: function () {
                alert("Emp not found - delEmp");
            }
        });
    }
}

function editEmp(id) {
    $.ajax({
        url: '/Ajax/EditEmp?eid=' + id,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf8;',
        success: function (response) {
            $('#exampleModal').modal('show');
            $('#exampleModalLabel').text("Update Emp");
            $('#Name').val(response.name);
            $('#Dept').val(response.dept);
            $('#Salary').val(response.salary);
            $('#savebtn').hide();
            $('#updbtn').show();
        },
        error: function () {
            alert("Emp not found - editEmp");
        }
    });
}

$('#updbtn').click(function () {
    var obj = $('#myform').serialize();
    $.ajax({
        url: '/Ajax/UpdateEmp',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf8;',
        data: obj,
        success: function () {
            alert("Emp Edit Successfully");
            clearform();
            $('#exampleModal').modal('hide');
            getEmpData();
        },
        error: function () {
            alert("Something wrong");
        }
    })
});




