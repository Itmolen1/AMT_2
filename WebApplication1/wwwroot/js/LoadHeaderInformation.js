$(function () {
    $("#CustomerId").change(function ()
    {
        var Id = parseInt($(this).val());
        if (Id > 0)
        {
            $.ajax({
                type: "POST",
                url: "/Customer/GetById/"+Id,
                success: function (response) {
                    $("#ContactPersonName").text(response.contactPerson == null ? "Contact Person" : "Contact Person "+response.contactPerson);
                    $("#MobileNumber").text(response.mobile == null ? "Mobile " : "Mobile :"+response.mobile);
                    $("#Address").text(response.address == null ? "Address :" : "Address :"+response.address);
                    $("#Email").text(response.email == null ? "E-Mail :" : "E-Mail : "+response.email);
                    $("#TRNNumber").text(response.trnNumber == null ? "TRN" :"TRN :" + response.trnNumber);

                    
                },
                failure: function (response) {
                    console.log(response);
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }
        else
        {
            $("#ContactPersonName").text("Contact Person");
            $("#MobileNumber").text("Mobile");
            $("#Address").text("Address");
            $("#Email").text("E-Mail");
            $("#TRNNumber").text("TRN");
        }
    });
});

