$(function () {
    if (window.location.pathname == "/Admin/Products") {
        $('#example').DataTable({
            order: [[0, 'desc']],
            destroy: true,
            searching: true,
            paging: true,
            "columnDefs": [
                { "orderable": false, "targets": [8] },
                { "searchable": false, "targets": 8 }
            ],
            "language": {
                "lengthMenu": "Hiển thị _MENU_ dữ liệu trên 1 trang",
                "zeroRecords": "Không tìm thấy",
                "info": "Hiển thị _PAGE_ / _PAGES_",
                "infoEmpty": "Không có dữ liệu",
                "infoFiltered": "(đã tìm kiếm tổng _MAX_ thông tin)",
                "search": "Tìm Kiếm:",
                "paginate": {
                    "first": "Đầu Trang",
                    "last": "Cuối Trang",
                    "next": "Tiếp Theo",
                    "previous": "Về Trước"
                },
            }
        });
    } else if (window.location.pathname == "/Admin/User") {
        $('#example').DataTable({
            order: [[0, 'desc']],
            destroy: true,
            searching: true,
            paging: true,
            "columnDefs": [
                { "orderable": false, "targets": [1,2,3,5] },
                { "searchable": false, "targets": [5] }
            ],
            "language": {
                "lengthMenu": "Hiển thị _MENU_ dữ liệu trên 1 trang",
                "zeroRecords": "Không tìm thấy",
                "info": "Hiển thị _PAGE_ / _PAGES_",
                "infoEmpty": "Không có dữ liệu",
                "infoFiltered": "(đã tìm kiếm tổng _MAX_ thông tin)",
                "search": "Tìm Kiếm:",
                "paginate": {
                    "first": "Đầu Trang",
                    "last": "Cuối Trang",
                    "next": "Tiếp Theo",
                    "previous": "Về Trước"
                },
            }
        });
    } else {
        $('#example').DataTable({
            order: [[0, 'desc']],
            destroy: true,
            searching: true,
            paging: true,
            "columnDefs": [
                { "orderable": false, "targets": [6, 7, 8] },
                { "searchable": false, "targets": [5, 7] }
            ],
            "language": {
                "lengthMenu": "Hiển thị _MENU_ dữ liệu trên 1 trang",
                "zeroRecords": "Không tìm thấy",
                "info": "Hiển thị _PAGE_ / _PAGES_",
                "infoEmpty": "Không có dữ liệu",
                "infoFiltered": "(đã tìm kiếm tổng _MAX_ thông tin)",
                "search": "Tìm Kiếm:",
                "paginate": {
                    "first": "Đầu Trang",
                    "last": "Cuối Trang",
                    "next": "Tiếp Theo",
                    "previous": "Về Trước"
                },
            }
        });
    }

    $('select[id^=selectActive]').on("change", function () {
        var id = $(this).attr('data-productid');
        var payment = $(this).find('option:selected').val();
        $.ajax({
            method: "PUT",
            url: "/Admin/Bills/updateActive/",
            data: {
                billId: id,
                payment: payment
            },
            dataType: "json"
        });
    });
});