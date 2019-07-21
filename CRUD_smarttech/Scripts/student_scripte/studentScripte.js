$(document).ready(function () {

    var api = "http://localhost:53662/api/student"

    //GET request to load all students
    $.ajax({
        url: api,   
        type: "GET",
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successLoadStudent,
        error: errorLoadStudent
    });

    function successLoadStudent(data, status)
    {
        if (data != null) {
            var html_indicator = "";
            var html_inner = "";
            debugger;

            console.log(data);
            $.each(data, function (key, value) {
                debugger;

                //first active element
                if (value.ID == 1)
                {
                    //create carousel-indicators
                    html_indicator += "<li data-target='" + value.ID + "' data-slide-to='" + value.ID + "' class='active'></li>";
                    $('#carsouel_indeicator').html(html_indicator);

                    
                    //create carousel-inner
                    html_inner += "<div class='carousel-item active'>";
                    if (value.Image == "")
                    {
                        html_inner += "<img src='" + '/images/avatar.png' + "' alt='img' width='1100' height='500'>";
                    }
                    else
                    {
                        var image_string = value.Image
                        html_inner += "<img src='" + image_string.replace("~/" , "") + "' alt='img' width='1100' height='500'>";
                    }
                    html_inner += "<div class='carousel-caption'>";
                    html_inner += "<h3>" + value.Name + "</h3>"
                    html_inner += "<h4>" + CalculateAge(value.DateOfBirth) + " Years Old</h4>"
                    //html_inner += "<input type='hidden' class='s_hidden_id" + value.ID + "' id='student_id' name='s_hidden' value='" + value.ID + "' />"
                    html_inner += "<input type='hidden' class='s_hidden_id' id='student_id' name='s_hidden' value='" + value.ID + "' />"
                    html_inner += "<input type='button' value='Edit' class='btn btn-success' id='edit_btn'/> | <input type='button' value='Delete' class='btn btn-danger' id='delete_btn' /> "
                    html_inner += "</div>";
                    html_inner += "</div>";

                    $('#carsouel_inner').html(html_inner);
                }
                else
                {
                    //create carousel-indicators
                    html_indicator += "<li data-target=" + value.ID + "' data-slide-to='" + value.ID + "'></li>";
                    $('#carsouel_indeicator').html(html_indicator);


                    //create carousel-inner
                    html_inner += "<div class='carousel-item'>";
                    if (value.Image == "" || value.Image == null) {
                        html_inner += "<img src='" + '~/images/avatar.png' + "' alt='img' width='1100' height='500'>";
                    }
                    else
                    {
                        var image_string = value.Image
                        html_inner += "<img src='" + image_string.replace("~/", "") + "' alt='img' width='1100' height='500'>";
                    }
                    html_inner += "<div class='carousel-caption'>";
                    html_inner += "<h3>" + value.Name + "</h3>"
                    html_inner += "<h4>" + CalculateAge(value.DateOfBirth) + " Years Old</h4>"
                    //html_inner += "<input type='hidden' class='s_hidden_id" + value.ID + "' id='student_id' name='s_hidden' value='" + value.ID + "' />"
                    html_inner += "<input type='hidden' class='s_hidden_id' id='student_id' name='s_hidden' value='" + value.ID + "' />"
                    html_inner += "<input type='button' value='Edit' class='btn btn-success' id='edit_btn' /> | <input type='button' value='Delete' class='btn btn-danger' id='delete_btn' /> "
                    html_inner += "</div>";
                    html_inner += "</div>";

                    $('#carsouel_inner').html(html_inner);
                }

            });

            //when user hit edit button
            var s_id = 0;
            $('.btn-success').on('click', function () {
                debugger;
                //get the active carsoual
                var active_carsoual = $('div.carousel-item.active');
                s_id = active_carsoual.find('.s_hidden_id').val();
                console.log('edit with sutdent ' + s_id);

                //"/Home/EditStudent?id=" + s_id;
                var url = '@Url.Action("EditStudent" , "Home" , new {id = "__id__"})'
                //window.location.href = url.replace('__id__', s_id);

                //location.href = "@Url.Action('EditStudent','Home' , new {id ='" + s_id + "'})";
                //window.location.url = "@Url.Action('EditStudent','Home' , new {id ='" + s_id + "'})";

                window.location = "Home/EditStudent?id=" + s_id;
                //window.location.href = '@Url.Action("EditStudent", "Home")/' + s_id;

                ////call ajax request to edit in edit student mvc action then pass id of student and render the view model of student form
                //$.ajax({
                //    url: "/Home/EditStudent",
                //    type: "GET",
                //    data: { id: s_id },
                //    contentType: "application/json; charset=utf-8",
                //    dataType: "json",
                //    success: function (data , status)
                //    {
                //        debugger;
                //        console.log(data.ID + ' ' + status);
                //        console.log(data.Name + ' ' + status);

                //        if (data.ID == 0)
                //        {
                //            alert('there is no such id');
                //            return;
                //        }
                //    },
                //    error: function (data , status)
                //    {
                //        if (data == 'fail')
                //        {
                //            alert('There is no such student to update');
                //        }
                //    }
                //});

            });


            //when user hit delete button
            $('.btn-danger').on('click', function () {
                debugger;
                var active_carsoual = $('div.carousel-item.active');
                s_id = active_carsoual.find('.s_hidden_id').val();
                console.log('delete with sutdent ' + s_id);
            });
        }
        else
        {

        }
    }
    function errorLoadStudent()
    {
        alert('error');
    }

    function CalculateAge(date)
    {
        debugger;
        var student_date = new Date(date);
        var current_date = new Date();
        var s_yaer = student_date.getFullYear();
        var c_year = current_date.getFullYear();
        var age = c_year - s_yaer;
        return age;
    }

});
