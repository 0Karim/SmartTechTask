/// <reference path="../jquery-3.3.1.min.js" />
/// <reference path="../jquery.validate.min.js" />
/// <reference path="../jquery.validate.unobtrusive.js" />


$(document).ready(function () {

    var wepApi = "http://localhost:53662/api/student";

    //function to display uploaded image
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#preview_image').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    //display image in the div
    $('#image').change(function () {
        readURL(this);
    });



    //add new student 
    $('#btn_register').on('click', function (event) {
        debugger;

        //disable when click 
        var _This = $(this);
        _This.attr("disable", "disable");

        var studentname = $('#name').val(),
            dateofBirth = $('#dateOfBirth').val(),
            mobile = $('#mobile').val(),
            address = $('#address').val(),
            faculty = $('#facultyid').val(),
            image = $('#image').val();



        if ($('form').valid())
        {
            var hidden_id = $('#student_id').val();

            if (hidden_id != 0) //update
            {
                if (image != "") // he change image so we need to upload again
                {
                    //here the action of upload file
                    //uploadFile();
                    debugger;
                    var filepath = '';
                    var formdata = new FormData(); //FormData object
                    var fileInput = document.getElementById('image');

                    for (i = 0; i < fileInput.files.length; i++) {
                        //Appending each file to FormData object
                        formdata.append(fileInput.files[i].name, fileInput.files[i]);
                    }

                    //Creating an XMLHttpRequest and sending
                    var xhr = new XMLHttpRequest();
                    xhr.open('POST', '/Home/UploadFile');
                    xhr.send(formdata);

                    xhr.onreadystatechange = function () {
                        if (xhr.readyState == 4 && xhr.status == 200) {
                            console.log(xhr.responseText);
                            var folderPath = '';

                            var mvc_api = "/Home/getFilePath"
                            $.ajax({
                                url: mvc_api,
                                type: "GET",
                                data: param = "",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: successLoadImage,
                                error: errorLoadImage
                            });

                            function successLoadImage(data, status) {
                                debugger;
                                if (data != null) {
                                    console.log(data);
                                    folderPath = data;


                                    //Send Ajax Request to Wep api to Add Student
                                    var student =
                                    {
                                        ID: hidden_id,
                                        Name: studentname,
                                        DateOfBirth: dateofBirth,
                                        Image: folderPath,
                                        Phone: mobile,
                                        Address: address,
                                        FacultyID: faculty
                                    }

                                    wepApi = "http://localhost:53662/api/student/edit"
                                    $.ajax({
                                        url: wepApi,
                                        type: "PUT",
                                        data: JSON.stringify(student),
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        success: successAddStudent,
                                        error: errorAddStudent
                                    });
                                    function successAddStudent(data, status) {
                                        //Model to display

                                        console.log(data);
                                        console.log(status);
                                        alert(data + ' ' + status);

                                        $('#name').val('');
                                        $('#dateOfBirth').val('');
                                        $('#mobile').val('');
                                        $('#address').val('');
                                        $('#facultyid').val('');
                                        $('#image').val('');
                                        $('preview_image').attr('src', 'data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==');;
                                    }
                                    function errorAddStudent(data, status) {
                                        alert('There is an error when Update Data id not found ' + data + status);
                                    }

                                    _This.removeAttr("disable"); //enable Edit Button
                                }
                            }
                            function errorLoadImage() {
                                alert('You Should upload Image');
                            }
                        }
                    }

                }
                else
                { //he not update the image and update another fields 
                    image = $('#image').attr('value');

                    debugger;
                    if (data != null) {
                        console.log(data);
                        folderPath = data;


                        //Send Ajax Request to Wep api to Add Student
                        var student =
                        {
                            ID: hidden_id,
                            Name: studentname,
                            DateOfBirth: dateofBirth,
                            Image: image,
                            Phone: mobile,
                            Address: address,
                            FacultyID: faculty
                        }

                        wepApi = "http://localhost:53662/api/student/edit"
                        $.ajax({
                            url: wepApi,
                            type: "PUT",
                            data: JSON.stringify(student),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: successAddStudent,
                            error: errorAddStudent
                        });
                        function successAddStudent(data, status) {
                            //Model to display

                            console.log(data);
                            console.log(status);
                            alert(data + ' ' + status);

                            $('#name').val('');
                            $('#dateOfBirth').val('');
                            $('#mobile').val('');
                            $('#address').val('');
                            $('#facultyid').val('');
                            $('#image').val('');
                            $('preview_image').attr('src', 'data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==');;
                        }
                        function errorAddStudent(data, status) {
                            alert('There is an error when Update Data' + data + status);
                        }

                        _This.removeAttr("disable"); //enable Edit Button
                    }

                }
            }
            else // Add
            {
                //here the action of upload file
                //uploadFile();
                debugger;
                var filepath = '';
                var formdata = new FormData(); //FormData object
                var fileInput = document.getElementById('image');

                for (i = 0; i < fileInput.files.length; i++) {
                    //Appending each file to FormData object
                    formdata.append(fileInput.files[i].name, fileInput.files[i]);
                }

                //Creating an XMLHttpRequest and sending
                var xhr = new XMLHttpRequest();
                xhr.open('POST', '/Home/UploadFile');
                xhr.send(formdata);

                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        console.log(xhr.responseText);
                        var folderPath = '';

                        var mvc_api = "/Home/getFilePath"
                        $.ajax({
                            url: mvc_api,
                            type: "GET",
                            data: param = "",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: successLoadImage,
                            error: errorLoadImage
                        });

                        function successLoadImage(data, status) {
                            debugger;
                            if (data != null) {
                                console.log(data);
                                folderPath = data;


                                //Send Ajax Request to Wep api to Add Student
                                var student =
                                {
                                    Name: studentname,
                                    DateOfBirth: dateofBirth,
                                    Image: folderPath,
                                    Phone: mobile,
                                    Address: address,
                                    FacultyID: faculty
                                }

                                wepApi = "http://localhost:53662/api/student/add"
                                $.ajax({
                                    url: wepApi,
                                    type: "POST",
                                    data: JSON.stringify(student),
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: successAddStudent,
                                    error: errorAddStudent
                                });
                                function successAddStudent(data, status) {
                                    //Model to display

                                    console.log(data);
                                    console.log(status);
                                    alert(data + ' ' + status);

                                    $('#name').val('');
                                    $('#dateOfBirth').val('');
                                    $('#mobile').val('');
                                    $('#address').val('');
                                    $('#facultyid').val('');
                                    $('#image').val('');
                                    $('preview_image').attr('src', 'data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==');;
                                }
                                function errorAddStudent(data, status) {
                                    alert('There is an error when insert Data' + data + status);
                                }

                                _This.removeAttr("disable"); //enable Edit Button
                            }
                        }
                        function errorLoadImage() {
                            alert('You Should upload Image');
                        }
                    }
                }
            }
        }
        else
        {
            //alert('Enter Form Data');
        }
    });
});





