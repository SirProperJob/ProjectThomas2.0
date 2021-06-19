$(document).ready(function () {
    $('#MrMen').DataTable({
        "paging": true,
        "ordering": true,
        "info": true,
        "columnDefs":
            [
                { "targets": [4], "orderable": false },
            ],
    });
});