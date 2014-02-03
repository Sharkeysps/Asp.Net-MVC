(function () {

    $(document).ready(function () {
        //original value of the element to be edited
        var oriVal;
        //index of the element li in the clicked ul
        var indexVal = -1;

        //all divs will be able to be editted with this
        $(".singEdit").click(function (event) {
            oriVal = $(this).text();
            $(this).text("");
            $("<input type='text' value='" + oriVal + "'>").appendTo(this).focus();
        });


        $("#parentUL").on('click', 'li', function () {
            oriVal = $(this).text();
            indexVal = $(" #parentUL li").index(this);
            $(this).text("");
            $("<input type='text' value='" + oriVal + "'>").appendTo(this).focus();
        });

        $("#skills").on('click', 'li', function () {
            oriVal = $(this).text();
            indexVal = $("#skills li").index(this);
            $(this).text("");
            $("<input type='text' value='" + oriVal + "'>").appendTo(this).focus();
        });

        //when we click outside the input field the text of the edited element will change
        $("ul").on('focusout', 'li > input', function () {
            var $this = $(this);
            $this.parent().text($this.val() || oriVal);
            $this.remove();
        });

        $(".singEdit").on('focusout', function () {
            var $this = $(this);
            var newVal = $("input").val()
            $this.text(newVal || oriVal);
        });


        $("#addSkill").click(function () {
            $("#skills").append('<li>Input');
        });

        $("#removeSkill").click(function () {
            if (indexVal == -1) {
                alert("Please select value to remove");
            } else {
                $("#skills li").eq(indexVal).remove();
                indexVal = -1;
            }
        });


        $("#add").click(function () {
            $("#parentUL").append('<li>Input');
        });

        $("#remove").click(function () {
            if (indexVal == -1) {
                alert("Please select value to remove");
            } else {
                $('#parentUL li').eq(indexVal).remove();
                indexVal = -1;
            }
        });

        //Gather all the data from the elements and post it to the controller in json format
        $("#save").click(function (event) {
            var skills = [];
            var work = [];
            $('#parentUL li').each(function () {
                work.push(this.innerText);
            });

            $('#skills li').each(function () {
                skills.push(this.innerText);
            })

            var name = $('#name').text();
            var email = $('#email').text();
            var repo = $('#repo').text();

            var jsonSkill = JSON.stringify(skills);
            var jsonWork = JSON.stringify(work);



            var parameters = {
                "Name": name,
                "Email": email,
                "Repository": repo,
                "Skills": skills,
                "WorkLife": work
            };

            var postData = JSON.stringify(parameters);
     
            //Change the url if it is different when testing
            $.ajax({
                type: 'POST',
                url: 'http://localhost:54048/Resume/UpdateResume/',
                data: postData,
                success: function (data) {
                    $("#success").text(data)
                },
                contentType: "application/json",
                dataType: 'json'
            });

        });

    });

}());