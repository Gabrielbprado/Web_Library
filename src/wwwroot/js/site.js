$(document).ready(function () {

    $('#emprestimos').DataTable(
        {

            Language:
            {

                "decimal": "",
                "emptyTable": "No data available in table",
                "info": "Mostrando _START_ Um _END_ De _TOTAL_ Entradas",
                "infoEmpty": "Showing 0 to 0 of 0 entries",
                "infoFiltered": "(filtered from _MAX_ total entries)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Carregando",
                "processing": "",
                "search": "Pesquisar:",
                "zeroRecords": "No matching records found",
                "paginate": {
                    "first": "Primeiro",
                    "last": "Ultimo",
                    "next": "Proximo",
                    "previous": "Anterior"
                },
                "aria": {
                    "sortAscending": ": activate to sort column ascending",
                    "sortDescending": ": activate to sort column descending"
                }
            }



        });

    setTimeout(function () {
        $('.alert').fadeOut('slow');
    },1000)
});