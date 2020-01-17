//======================================================================
//Add players to list
function AddPlayerToList() {
    var span = $("span#playerSelect")
    var text = span.text();
    var liTag = document.getElementsByTagName("li");
    var id = 'undefined';

    for (var i = 0; i < liTag.length; i++) {
        if (liTag[i].textContent == text) {
            id = liTag[i].id;
            span.text('Select Players');
            liTag[i].remove();
            break;
        }
    }

    if (id != 'undefined') {
        var li = document.createElement("li");
        li.id = id;
        li.innerHTML = text;

        var ul = document.getElementById('playerListId');
        ul.appendChild(li);
    }
}

//======================================================================
//Search filter
function filterFunction() {
    var input, filter, ul, li, i;
    input = document.getElementById("inputFilter");
    filter = input.value.toUpperCase();
    ul = document.getElementById("dropdownMenuId");
    li = ul.getElementsByTagName("li");

    for (i = 0; i < li.length; i++) {
        if (li[i].id != "nonClick") {
            txtValue = li[i].textContent || li[i].innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                li[i].style.display = "";
            } else {
                li[i].style.display = "none";
            }
        }
    }
}

//======================================================================
//Send player list
function SendList() {

    var limit = document.getElementById("inputLimit").value;
    var dataStream = '';
    var dataStreamLen = 0;
    var liTag = document.getElementsByTagName("li");
    for (var i = 0; i < liTag.length; i++) {
        if (liTag[i].parentNode.id == 'playerListId') {
            dataStream += liTag[i].id + ";";
            dataStreamLen++;
        }
    }

    if (dataStreamLen > 1) {
        $.ajax({
            url: '/Game/StartGame',
            data: {
                dataStream: dataStream,
                limit: limit
            },
            type: "POST",
        }).done(function (url) {
            window.location.href = url.newUrl;
        }).fail(function (xhr, a, error) {
            console.log(error);
        });
    }
}