"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

//Disable the send button until connection is established.
document.getElementById("chat-submit").disabled = true;

let INDEX = 0;
connection.on("RecieveMessage", function (msg) {
        if (msg.trim() == '') {
            return false;
        }
        generate_message(msg, 'self');
        var buttons = [
            {
                name: 'Existing User',
                value: 'existing'
            },
            {
                name: 'New User',
                value: 'new'
            }
        ];
        setTimeout(function () {
            generate_message(msg, 'user');
        }, 1000)

    //var li = document.createElement("li");
    //document.getElementById("messagesList").appendChild(li);
    //// We can assign user-supplied strings to an element's textContent because it
    //// is not interpreted as markup. If you're assigning in any other way, you 
    //// should be aware of possible script injection concerns.
    //li.textContent = message;
});
function generate_message(msg, type) {
    INDEX++;
    var str = "";
    str += "<div id='cm-msg-" + INDEX + "' class=\"chat-msg " + type + "\">";
    str += "          <div class=\"cm-msg-text\">";
    str += msg;
    str += "          <\/div>";
    str += "        <\/div>";
    $(".chat-logs").append(str);
    $("#cm-msg-" + INDEX).hide().fadeIn(300);
    if (type == 'self') {
        $("#chat-input").val('');
    }
    $(".chat-logs").stop().animate({ scrollTop: $(".chat-logs")[0].scrollHeight }, 1000);
    msg = "";
}

connection.start().then(function () {
    document.getElementById("chat-submit").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("chat-submit").addEventListener("click", function (event) {
    var msg = $("#chat-input").val();
    // var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage",/* "this is a test message"*/msg).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


function generate_button_message(msg, buttons) {
        /* Buttons should be object array
          [
            {
              name: 'Existing User',
              value: 'existing'
            },
            {
              name: 'New User',
              value: 'new'
            }
          ]
        */
        INDEX++;
        var btn_obj = buttons.map(function (button) {
            return "              <li class=\"button\"><a href=\"javascript:;\" class=\"btn btn-primary chat-btn\" chat-value=\"" + button.value + "\">" + button.name + "<\/a><\/li>";
        }).join('');
        var str = "";
        str += "<div id='cm-msg-" + INDEX + "' class=\"chat-msg user\">";
        str += "          <div class=\"cm-msg-text\">";
        str += msg;
        str += "          <\/div>";
        str += "          <div class=\"cm-msg-button\">";
        str += "            <ul>";
        str += btn_obj;
        str += "            <\/ul>";
        str += "          <\/div>";
        str += "        <\/div>";
        $(".chat-logs").append(str);
        $("#cm-msg-" + INDEX).hide().fadeIn(300);
        $(".chat-logs").stop().animate({ scrollTop: $(".chat-logs")[0].scrollHeight }, 1000);
        $("#chat-input").attr("disabled", true);
    }
    $(document).delegate(".chat-btn", "click", function () {
        var value = $(this).attr("chat-value");
        var name = $(this).html();
        $("#chat-input").attr("disabled", false);
        generate_message(name, 'self');
    })

    $("#chat-circle").click(function () {
        $("#chat-circle").toggle('scale');
        $(".chat-box").toggle('scale');
    })

    $(".chat-box-toggle").click(function () {
        $("#chat-circle").toggle('scale');
        $(".chat-box").toggle('scale');
    })
