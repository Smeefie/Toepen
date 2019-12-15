//======================================================================
//Player winning
function PlayerWin(btn) {
    var playerList = CreatePlayerList();

    $.ajax({
        type: "POST",
        url: '/Game/PlayerWonRound',
        data:
        {
            winPlayer: $(btn).val(),
            json: JSON.stringify({ 'list': playerList })
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

            playerList.push(player);
        }
    }
    return playerList
}

//======================================================================
//Player knocking
function PlayerKnock(btn) {
    $.ajax({
        url: '/Game/PlayerKnocks',
        data: { playerId: $(btn).val() },
        type: "POST",
    })
}