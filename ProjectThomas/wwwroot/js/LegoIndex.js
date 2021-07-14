$(document).ready(function () {
    $('#Lego').DataTable({
        "paging": true,
        "ordering": true,
        "info": true,
        "columnDefs":
            [
                { "targets": [5], "orderable": false },
            ],
    });
});