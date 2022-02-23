 
$(function () {
    $("#example1").DataTable({
        "responsive": false, "lengthChange": true, "autoWidth": false,
        // "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
       // "buttons": ["excel", "pdf", "print"]
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
    //$('#example2').DataTable({
    //    "paging": true,
    //    "lengthChange": false,
    //    "searching": false,
    //    "ordering": true,
    //    "info": true,
    //    "autoWidth": false,
    //    "responsive": true,
    //});
});

$(function () {
    $(document).ready(function () {
        // Run code
        $.ajax({
            type: "POST",
            url: "/Home/GetWidgetsDetails",
            success: function (response) {
                $("#TotalEmployee").text(response.totalEmployee);
                $("#TotalVehicle").text(response.totalVehicle);
                $("#TotalQuotaion").text(response.totalQuotaion);
                $("#TotalInvoice").text(response.totalInvoice);
            },
            failure: function (response) {
                console.log(response);
            },
            error: function (response) {
                console.log(response);
            }
        });
    });
});
