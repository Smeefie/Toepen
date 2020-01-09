//======================================================================
//Player winning
function PlayerWin(btn) {
    var playerList = CreatePlayerList();
    var jackCheck = $('#cbx').is(":checked");

    $.ajax({
        type: "POST",
        url: '/Game/PlayerWonRound',
        data:
        {
            winPlayer: $(btn).val(),
            json: JSON.stringify({ 'list': playerList }),
            scoreLimit: document.getElementById('scoreLimit').innerHTML,
            roundCount: document.getElementById("roundCounter").innerHTML,
            jack: jackCheck,
        }
    }).done(function (partialViewResult) {
        $("#GameContainer").html(partialViewResult);
    }).fail(function (xhr, textStatus, errorThrown) {
        alert(xhr.responseText);
    });
}

function CreatePlayerList() {
    var playerList = [];
    var liTag = document.getElementsByTagName("li");
    for (var i = 0; i < liTag.length; i++) {
        if (liTag[i].parentNode.id == 'ulpref') {
            player = {};
            player.Id = parseInt(liTag[i].querySelector('#id').textContent);
            player.Username = liTag[i].querySelector('#username').textContent;
            player.Score = parseInt(liTag[i].querySelector('#score').textContent);
            player.Knocked = parseInt(liTag[i].querySelector('#knocked').textContent);
            player.Won = parseInt(liTag[i].querySelector('#won').textContent);
            player.Lost = parseInt(liTag[i].querySelector('#lost').textContent);

            if (parseInt(liTag[i].querySelector('#won').textContent) != 0) player.Won = 1;
            if (parseInt(liTag[i].querySelector('#lost').textContent) != 0) player.Lost = 1;

            playerList.push(player);
        }
    }
    return playerList
}

//======================================================================
//Player knocking
function PlayerKnock(btn) {
    var playerList = CreatePlayerList();

    $.ajax({
        type: "POST",
        url: '/Game/PlayerKnocks',
        data:
        {
            knockPlayer: $(btn).val(),
            json: JSON.stringify({ 'list': playerList }),
            limit: document.getElementById('scoreLimit').innerHTML,
            roundCount: document.getElementById("roundCounter").innerHTML
        }
    }).done(function (partialViewResult) {
        $("#GameContainer").html(partialViewResult);
    }).fail(function (xhr, textStatus, errorThrown) {
        alert(xhr.responseText);
    });
}