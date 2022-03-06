$('#btnaddRow').click(function () {
    var currentrow = $(this).closest("tr");
    var vat = currentrow.find('.vat').val();
    //RowSubTalSubtotal(vat, currentrow);
    //CombineTotalAndSubtotal();
    //CombineTotal();
    //CalculateVateTotal();

    var isAllValid = true;
    if ($("#mainrowgood #drpgoods").val() == "0") {
        isAllValid = false;
        //swal("Let op!", "Selecteer product", "warning");
        alert('select Product');
        return;
    }
    var isAllValid = true;
    if ($("#mainrowgood #Unit").val() == "0") {
        isAllValid = false;
        //swal("Let op!", "Selecteer product", "warning");
        alert('select Unit');
        return;
    }

    var isAllValid = true;
    if ($("#mainrowgood .quantity").val() == 0) {
        isAllValid = false;
        alert('Add Quantity')
        // swal("Let op!", "Voer aantal in", "warning");
        return;
    }

    var isAllValid = true;
    if ($("#mainrowgood .rate").val() == 0) {
        isAllValid = false;
        // swal("Let op!", "Voer inkoopprijs in", "warning");
        alert('Add rate')
        return;
    }

    if (isAllValid) {
        var $newRow = $("#mainrowgood").clone().removeAttr('id');
        $('#drpgoods', $newRow).val($("#drpgoods").val());
        $('.vat', $newRow).val($("#mainrowgood .vat").val());
        $('.Unit', $newRow).val($("#mainrowgood .Unit ").val());
        $("#btnaddRow", $newRow).addClass('remove btn btn-danger').val('x').removeClass('btn-success').addClass('btn-height-Remove');
        $("#drpgoods,#Quantity,#rate,#rowsubtotal,#rownettotal,#vat", $newRow).removeAttr('id');

        $('.tbodyGood tr:last').before($newRow);
        $(".rowsubtotal").prop('disabled', true);
        $(".rownettotal").prop('disabled', true);
        //$('#mainrowgood #drpgoods').select2().select2('val', '0');
        $('#mainrowgood #drpgoods').val(0);
        $('#mainrowgood #Unit').val(0);
        $('#mainrowgood #quantity').val(0.00);
        $('#mainrowgood #UPrice').val(0.00);
        $('#mainrowgood #VAT').val(0);
        $('#mainrowgood #Description').val('');
        $('#mainrowgood #SubTotal').val(0.00);
        $('#mainrowgood #RowSubTotal ').val(0.00);

        // clearfield();

        CountTotalVat();
    }
});

function CountTotalVat() {

    var TotalVAT = 0.00;
    var GTotal = 0.00;
    var ToatWTVAT = 0.00;

    $('#orderdetailsitems .tbodyGood tr').each(function () {

        var PId = $(this).find(".product").val();

        if (PId > 0) {
            if ($(this).find(".rownettotal").val() == "NaN") {
                return true;
            }
            else if ($(this).find(".RowSubTotal").val() == "NaN") {
                return true;
            }
            else {
                GTotal = parseFloat(GTotal) + parseFloat($(this).find(".rownettotal").val());
                ToatWTVAT = parseFloat(ToatWTVAT) + parseFloat($(this).find(".RowSubTotal").val());
                TotalVAT = parseFloat(GTotal) - parseFloat(ToatWTVAT);
            }
        }
    });
    $("#TotalVAT").text(TotalVAT.toFixed(2));
    $("#SubTotal").text(ToatWTVAT.toFixed(2));
    $("#gtotal").text(GTotal.toFixed(2));

}

function IsOneDecimalPoint(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

$(document).on('click', '.remove', function () {
    var Current = $(this).closest('tr');
    Current.remove();
    CountTotalVat();
});

$(document).on("keyup", '.rate', function (evt) {
    var Currentrow = $(this).closest("tr");
    var QTY = Currentrow.find('.quantity').val();

    if (parseInt(QTY) >= 0) {

        var Total = parseFloat(QTY) * parseFloat(Currentrow.find('.rate').val());
        Currentrow.find('.RowSubTotal').val(parseFloat(Total).toFixed(2));
    }

    var vat = Currentrow.find('.vat').val();
    RowSubTalSubtotal(vat, Currentrow);
    CountTotalVat();
});

$(document).on("keyup", '.quantity', function (e) {

    var Currentrow = $(this).closest("tr");
    var QTY = $(this).val();

    if (parseInt(QTY) >= 0) {

        var Total = parseFloat(QTY) * parseFloat(Currentrow.find('.rate').val());

        Currentrow.find('.RowSubTotal').val(parseFloat(Total).toFixed(2));
    }
    var vat = Currentrow.find('.vat').val();
    RowSubTalSubtotal(vat, Currentrow);
    CountTotalVat();
});

$(document).on("change", '.vat', function () {
    var Currentrow = $(this).closest("tr");
    var vat = Currentrow.find('.vat').val();
    RowSubTalSubtotal(vat, Currentrow);
    CountTotalVat();
});

function RowSubTalSubtotal(vat, CurrentRow) {
    Total = 0;
    Total = CurrentRow.find('.RowSubTotal').val();
    if (parseInt(vat) == 0 && typeof (vat) != "undefined" && vat != "") {
        if (!isNaN(Total) && typeof (Total) != "undefined") {
            CurrentRow.find('.rownettotal  ').val(Total);
            CurrentRow.find('.rownettotal  ').val(parseFloat(Total).toFixed(2));
            return;
        }
    }

    if (!isNaN(Total) && Total != "" && typeof (vat) != "undefined") {
        var InputVatValue = parseFloat((Total / 100) * vat);
        var ValueWTV = parseFloat(InputVatValue) + parseFloat(Total);
        CurrentRow.find('.rownettotal').val(parseFloat(ValueWTV).toFixed(2));
    }
}

function validateRow(currentRow) {

    var isvalid = true;
    var productId = 0, quantityG = 0, varrateG = 0;
    productId = currentRow.find('.product').val();
    quantity = currentRow.find('.quantity ').val();
    rate = currentRow.find('.rate ').val();
    if (parseInt(productId) == 0 || productId == "") {
        isvalid = false;
    }
    if (parseInt(quantity) == 0 || quantity == "") {
        isvalid = false;
    }
    if (parseInt(rate) == 0 || rate == "") {
        isvalid = false;
    }
    return isvalid;
}

function IsOneDecimalPoint(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

$("#SaveQuotation").click(function () {
    var Id = $("#Id").val();
    if (Id > 0) {
        CreateQuotation("/Quotation/Update");
    }
    else {
        CreateQuotation("/Quotation/Create");
    }

});

function CreateQuotation(Url) {
    if (1 == 1) {

        var list = [], orderItem, CurrentRow;
        var formData = new FormData();

        $('#orderdetailsitems .tbodyGood tr').each(function () {
            CurrentRow = $(this).closest("tr");
            if (validateRow(CurrentRow)) {
                if (1 == 1) {
                    orderItem = {
                        Id: parseInt($(this).find('.detailId').val()),
                        ItemId: parseInt($(this).find('.product').val()),                        
                        Description: $(this).find('.Description').val(),
                        UnitId: parseInt($(this).find('.Unit').val()),
                        UnitPrice: parseFloat($(this).find('.rate').val()),
                        Quantity: parseFloat($(this).find('.quantity').val()),
                        Total: parseFloat($(this).find('.RowSubTotal').val()),
                        VAT: parseInt($(this).find('.vat').val()),
                        SubTotal: parseInt($(this).find('.rownettotal').val()),
                    }
                    list.push(orderItem);
                }
            }
        })

        if (list.length == 0) {
            $('#SubTotal').text('');
            $('#TotalVAT').text('');
            $('#gtotal').text('');
        }

        var empObj = {
            QuotationNumber: $('#QuotationNumber').text(),
            Id: $('#Id').val(),
            //RefrenceNumber: $('#RefrenceNo').val(),
            FromDate: $('#FromDate').val(),
            DueDate: $('#FromDate').val(),
            TotalAmount: $('#TotalAmount').text(),
            VAT: $('#TotalVAT').text(),
            GrandTotalAmount: $('#gtotal').text(),
            TermCondition: $('#TermCondition').val(),
            CustomerNote: $('#CustomerNote').val(),
            CustomerId: $('#CustomerId').val(),
            //ProjectId: $('#project').val(),
        };

        for (var key in empObj) {
            formData.append(key, empObj[key]);
        }

        for (var i = 0; i < list.length; i++) {
            formData.append('QuotationDetails[' + i + '][Id]', list[i].Id)
            formData.append('QuotationDetails[' + i + '][ItemId]', list[i].ItemId)
            formData.append('QuotationDetails[' + i + '][Quantity]', list[i].Quantity)
            formData.append('QuotationDetails[' + i + '][UnitPrice]', list[i].UnitPrice)
            formData.append('QuotationDetails[' + i + '][Total]', list[i].Total)
            formData.append('QuotationDetails[' + i + '][VAT]', list[i].VAT)
            formData.append('QuotationDetails[' + i + '][SubTotal]', list[i].SubTotal)
            formData.append('QuotationDetails[' + i + '][Description]', list[i].Description)
            formData.append('QuotationDetails[' + i + '][UnitId]', list[i].UnitId)
        }
        if (list.length > 0) {
            $.ajax({
                url: Url,
                type: "POST",
                data: formData,
                dataType: 'json',
                contentType: false,
                processData: false,
                success: function (result)
                {
                    if (result != "Failed") {
                        list = [];
                        alert("Added SuccessFully");
                        window.location.href = "/Quotation/Details/" + result;
                    }
                    else if (result == "NotValid")
                    {
                        alert("Please check your entries and then click on save")
                    }
                    else {
                        alert("Problem in adding new quotation! Please reload page try again")
                    }
                },
                error: function (errorMessage)
                {
                    console.log(errorMessage);
                }
            });
        }
    }   
}

