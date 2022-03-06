$("#SaveExpense").click(function () {

    alert('clcicked');
});


$("#Category").change(function () {

    var value = $(this).val();

    if (value == "0") {
        return true;
    }
    else if (value == "General") {
        alert("g");
    }
    else if (value == "Employee") {
        alert("emp");
    }
    else {
        alert("v");
    }

});