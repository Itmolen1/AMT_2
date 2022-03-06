 
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
    $(".dataTables_length").css('margin-left', '20px');
    $(".dataTables_info").css('margin-left', '20px').css('color', '#87CEEB');
    $(".dataTables_length").css('margin-top', '10px');
    $(".dataTables_filter").css('margin-right', '10px');
    $(".dataTables_filter").css('margin-top', '10px');    
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
