function SaveTask() {
    var frm = $("#formTask").serialize();
    console.log(frm);
    //Salvar tarefa via ajax
    $.ajax({
        url: SaveForm,
        type: 'POST',
        dataType: 'json',
        data: frm,
        success: function (data) {
            console.log(data);
            $('#Task').val('');
            if (data.Status == true) {
                $("#TaskList").append(
                '<li class="mdl-card mdl-shadow--4dp mdl-cell mdl-cell--12-col mdl-list__item" onclick="ChangeStatus(' + data.TaskId + ')" id="' + data.TaskId + '">' +
                    '<span class="mdl-list__item-primary-content">' +
                        '<span class="description description-em-andamento">' + data.Description + '</span>' +
                        '<span class="mdl-list__item-sub-title status status-em-andamento">Em Andamento</span>' +
                    '</span>' +
                '</li>'
                );
            } else {
                $("#TaskList").append(
                '<li class="mdl-card mdl-shadow--4dp mdl-cell mdl-cell--12-col mdl-list__item" onclick="ChangeStatus(' + data.TaskId + ')" id="' + data.TaskId + '">' +
                    '<span class="mdl-list__item-primary-content">' +
                        '<span class="description description-pronto">' + data.Description + '</span>' +
                        '<span class="mdl-list__item-sub-title status status-pronto">Pronto</span>' +
                    '</span>' +
                '</li>'
                );
            }

        },
        error: function (data) {
            alert('Não foi possível salvar sua tarefa' + data);
        }
    });
}

function ChangeStatus(TaskID) {
    console.log(TaskID);
    //Alterar Status via ajax
    $.ajax({
        url: ChangeStatusTask,
        type: 'POST',
        dataType: 'json',
        data: { TaskId: JSON.stringify(TaskID) },
        success: function (data) {
            console.log(data);
            if (data.Status == true) {
                $('#' + data.TaskId + ' .description').removeClass("description-pronto").addClass("description-em-andamento");
                $('#' + data.TaskId + ' .status').removeClass("status-pronto").addClass("status-em-andamento").html("Em Andamento");
            } else {
                $('#' + data.TaskId + ' .description').removeClass("description-em-andamento").addClass("description-pronto");
                $('#' + data.TaskId + ' .status').removeClass("status-em-andamento").addClass("status-pronto").html("Pronto");
            }
        },
        error: function (data) {
            alert('Não foi possível alterar o status da tarefa' + data);
        }
    });
}