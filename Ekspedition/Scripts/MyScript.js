$(document).ready(function () {
    $('#updateadmin').click(function () {
        var isAllValid = true;
        //validate order items
        if ($('#efirstname').val().trim() == '') {
            $('#efirstname').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#efirstname').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#elastname').val().trim() == '') {
            $('#elastname').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#elastname').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#eposition').val().trim() == '') {
            $('#eposition').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#eposition').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#ebranch').val().trim() == '') {
            $('#ebranch').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#ebranch').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#eusername').val().trim() == '') {
            $('#eusername').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#eusername').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#epassword').val().trim() == '') {
            $('#epassword').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#epassword').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            $('#updateadmin').css('background-color', '#ffcc00').css('color','black');
            $('#updateadmin').text('Please wait ...'); // jika button menggunakan .val
            //alert('Hai Valid');
            var data = {
                Id: $('#eid').val().trim(),
                FirstName: $('#efirstname').val().trim(),
                LastName: $('#elastname').val().trim(),
                Position: $('#eposition').val().trim(),
                Username: $('#eusername').val().trim(),
                Password: $('#epassword').val().trim(),
                Branch_Id: $('#ebranch').val().trim()
            }
            //alert('Hai All Data Valid');
            //alert(data.Id + '-' + data.FirstName + '-' + data.LastName + '-' + data.Position + '-' + data.Username + '-' + data.Password + '-' + data.Branch_Id);
            $.ajax({
                type: 'POST',
                url: '/DashboardAdmin/Edit',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        $('#updateadmin').css('visibility', 'hidden');
                        $('#closeedit').css('visibility', 'hidden');
                        alert('Successfully saved');
                        window.location.href = data.Url;
                        //here we will clear the form
                        //$('#efirstname,#elastname,#eposition,#eusername,#epassword').val('');
                    }
                    else {
                        alert('Check your Form'); 
                        $('#updateadmin').css('background-color', '#ff3333').css('color', 'white');
                        $('#updateadmin').text('Save Changes');
                    }
                },
                error: function (error) {
                    alert('No Function Found');
                    alert(data.Id + '-' + data.FirstName + '-' + data.LastName + '-' + data.Position + '-' + data.Username + '-' + data.Password + '-' + data.Branch_Id);
                    alert(data);
                    console.log(error);
                }
            });
        }
    });
});

$(document).ready(function () {
    $('#cek').click(function () {
        alert('Hai');
    });
});