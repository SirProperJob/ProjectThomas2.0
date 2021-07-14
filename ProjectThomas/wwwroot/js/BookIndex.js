$(document).ready(function () {
    $('#Book').DataTable({
        "paging": true,
        "ordering": true,
        "info": true,
        "columnDefs":
            [
                { "targets": [6], "orderable": false },
            ],
    });
});