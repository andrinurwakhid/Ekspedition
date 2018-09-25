$(document).ready(function () {
    $('#btneditcategorys').click(function () {
        alert("Andri");
    });
    $('#btneditcategory').click(function() {

        var data1 = document.getElementById('categoryid');
        var data2 = document.getElementById('categoryname');
        $('#cid').val(data1.textContent);
        $('#cname').val(data2.textContent);
    });

    $('#AddCategory').click(function () {

        var isAllValid = true;
        if ($('#cname').val().trim() == '') {
            $('#cname').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#cname').siblings('span.error').css('visibility', 'hidden');
        }
        if (isAllValid) {
            $('#AddCategory').css('background-color', '#ffcc00').css('color', 'black');
            $('#AddCategory').text('Please wait ...');
            var data = {
                Name: $('#cname').val().trim()
            }

            $.ajax({
                type: 'POST',
                url: '/ManageApps/AddCategory',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        $('#AddCategory').css('visibility', 'hidden');
                        $('#CloseAddCategory').css('visibility', 'hidden');
                        alert('Successfully saved');
                        window.location.href = data.Url;
                        //here we will clear the form
                        //$('#efirstname,#elastname,#eposition,#eusername,#epassword').val('');
                    }
                    else {
                        alert('Check your Form');
                        $('#AddCategory').css('background-color', '#ff3333').css('color', 'white');
                        $('#AddCategory').text('Save Changes');
                    }
                },
                error: function (error) {
                    alert('No Function Found');
                    alert(data.Name);
                    alert(data);
                    console.log(error);
                }
            });
        }
    });

    $('#AddStatus').click(function () {

        var isAllValid = true;
        if ($('#sname').val().trim() == '') {
            $('#sname').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#sname').siblings('span.error').css('visibility', 'hidden');
        }
        if (isAllValid) {
            $('#AddStatus').css('background-color', '#ffcc00').css('color', 'black');
            $('#AddStatus').text('Please wait ...');
            var data = {
                Name: $('#sname').val().trim()
            }

            $.ajax({
                type: 'POST',
                url: '/ManageApps/AddStatus',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        $('#AddStatus').css('visibility', 'hidden');
                        $('#CloseAddStatus').css('visibility', 'hidden');
                        alert('Successfully saved');
                        window.location.href = data.Url;
                        //here we will clear the form
                        //$('#efirstname,#elastname,#eposition,#eusername,#epassword').val('');
                    }
                    else {
                        alert('Check your Form');
                        $('#AddStatus').css('background-color', '#ff3333').css('color', 'white');
                        $('#AddStatus').text('Save Changes');
                    }
                },
                error: function (error) {
                    alert('No Function Found');
                    alert(data.Name);
                    alert(data);
                    console.log(error);
                }
            });
        }
    });

    $('#AddBranch').click(function () {

        var isAllValid = true;
        if ($('#bname').val().trim() == '') {
            $('#bname').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#bname').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#bprovince').val().trim() == '') {
            $('#bprovince').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#bprovince').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#bregency').val().trim() == '') {
            $('#bregency').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#bregency').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#bdistrict').val().trim() == '') {
            $('#bdistrict').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#bdistrict').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#bvillage').val().trim() == '') {
            $('#bvillage').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#bvillage').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#baddress').val().trim() == '') {
            $('#baddress').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#baddress').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#bprice').val().trim() == '') {
            $('#bprice').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#bprice').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#bwarehouse').val().trim() == '') {
            $('#bwarehouse').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#bwarehouse').siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllValid) {
            $('#AddBranch').css('background-color', '#ffcc00').css('color', 'black');
            $('#AddBranch').text('Please wait ...');
            var data = {
                Name: $('#bname').val(),
                Province_Id: $('#bprovince').val(),
                Regency_Id: $('#bregency').val(),
                District_Id: $('#bdistrict').val(),
                Village_Id: $('#bvillage').val(),
                Address: $('#baddress').val(),
                Warehouse_Id: $('#bwarehouse').val(),
                Price: $('#bprice').val()
            }
            alert('Hai Data');
            alert(data.Name + '-' + data.Province_Id + '-' + data.Regency_Id + '-' + data.District_Id + '-' + data.Village_Id + '-' + data.Address + '-' + data.Price + '-' + data.Warehouse_Id);
            $.ajax({
                type: 'POST',
                url: '/ManageApps/AddBranch',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        $('#AddBranch').css('visibility', 'hidden');
                        $('#CloseAddBranch').css('visibility', 'hidden');
                        alert('Successfully saved');
                        window.location.href = data.Url;
                        //here we will clear the form
                        //$('#efirstname,#elastname,#eposition,#eusername,#epassword').val('');
                    }
                    else {
                        alert('Check your Form');
                        $('#AddBranch').css('background-color', '#ff3333').css('color', 'white');
                        $('#AddBranch').text('Save Changes');
                    }
                },
                error: function (error) {
                    alert('No Function Found');
                    console.log(error);
                }
            });
        }
    });

    $('#AddWarehouse').click(function () {

        var isAllValid = true;
        if ($('#wname').val().trim() == '') {
            $('#wname').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#wname').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#wprovince').val().trim() == '') {
            $('#wprovince').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#wprovince').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#wregency').val().trim() == '') {
            $('#wregency').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#wregency').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#wdistrict').val().trim() == '') {
            $('#wdistrict').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#wdistrict').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#wvillage').val().trim() == '') {
            $('#wvillage').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#wvillage').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#waddress').val().trim() == '') {
            $('#waddress').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#waddress').siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllValid) {
            $('#AddWarehouse').css('background-color', '#ffcc00').css('color', 'black');
            $('#AddWarehouse').text('Please wait ...');
            var data = {
                Name: $('#wname').val(),
                Province_Id: $('#wprovince').val(),
                Regency_Id: $('#wregency').val(),
                District_Id: $('#wdistrict').val(),
                Village_Id: $('#wvillage').val(),
                Address: $('#waddress').val()
            }
            alert('Hai Data');
            alert(data.Name + '-' + data.Province_Id + '-' + data.Regency_Id + '-' + data.District_Id + '-' + data.Village_Id + '-' + data.Address);
            $.ajax({
                type: 'POST',
                url: '/ManageApps/AddWarehouse',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        $('#AddWarehouse').css('visibility', 'hidden');
                        $('#CloseAddWarehouse').css('visibility', 'hidden');
                        alert('Successfully saved');
                        window.location.href = data.Url;
                        //here we will clear the form
                        //$('#efirstname,#elastname,#eposition,#eusername,#epassword').val('');
                    }
                    else {
                        alert('Check your Form');
                        $('#AddWarehouse').css('background-color', '#ff3333').css('color', 'white');
                        $('#AddWarehouse').text('Save Changes');
                    }
                },
                error: function (error) {
                    alert('No Function Found');
                    console.log(error);
                }
            });
        }
    });

    $('#AddPackage').click(function () {

        var isAllValid = true;
        if ($('#pname').val().trim() == '') {
            $('#pname').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#pname').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#pprice').val().trim() == '') {
            $('#pprice').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#pprice').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            $('#AddPackage').css('background-color', '#ffcc00').css('color', 'black');
            $('#AddPackage').text('Please wait ...');
            var data = {
                Name: $('#pname').val().trim(),
                Price: $('#pprice').val().trim()
            }

            $.ajax({
                type: 'POST',
                url: '/ManageApps/AddPackage',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        $('#AddPackage').css('visibility', 'hidden');
                        $('#CloseAddPackage').css('visibility', 'hidden');
                        alert('Successfully saved');
                        window.location.href = data.Url;
                        //here we will clear the form
                        //$('#efirstname,#elastname,#eposition,#eusername,#epassword').val('');
                    }
                    else {
                        alert('Check your Form');
                        $('#AddPackage').css('background-color', '#ff3333').css('color', 'white');
                        $('#AddPackage').text('Save Changes');
                    }
                },
                error: function (error) {
                    alert('No Function Found');
                    alert(data.Name);
                    alert(data);
                    console.log(error);
                }
            });
        }
    });
});