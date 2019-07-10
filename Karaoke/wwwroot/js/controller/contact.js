﻿var TableDatatablesAjax = function () {

    var initPickers = function () {
        //init date pickers
        $('.date-picker').datepicker({
            rtl: App.isRTL(),
            autoclose: true
        });
    }

    var handleRecords = function () {

        var grid = new Datatable();

        grid.init({
            src: $("#datatable_ajax"),
            onSuccess: function (grid, response) {
                // grid:        grid object
                // response:    json object of server side ajax response
                // execute some code after table records loaded
            },
            onError: function (grid) {
                // execute some code on network or other general error  
            },
            onDataLoad: function (grid) {
                // execute some code on ajax data load
            },
            loadingMessage: 'Loading...',
            dataTable: { // here you can define a typical datatable settings from http://datatables.net/usage/options 

                // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
                // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/scripts/datatable.js). 
                // So when dropdowns used the scrollable div should be removed. 
                //"dom": "<'row'<'col-md-8 col-sm-12'pli><'col-md-4 col-sm-12'<'table-group-actions pull-right'>>r>t<'row'<'col-md-8 col-sm-12'pli><'col-md-4 col-sm-12'>>",

                "bStateSave": true, // save datatable state(pagination, sort, etc) in cookie.
                "bDestroy": true,

                "lengthMenu": [
                    [10, 20, 50, 100, 150, -1],
                    [10, 20, 50, 100, 150, "All"] // change per page values here
                ],
                "pageLength": 10, // default record count per page
                "ajax": {
                    "url": "/Admin/Contact/LoadTable", // ajax source
                },
                "columnDefs": [{ // define columns sorting options(by default all columns are sortable extept the first checkbox column)
                    'orderable': false,
                    'targets': [0],
                    'checkboxes': {
                        'selectRow': true
                    }
                }],
                "order": [
                    [0, "asc"]
                ],// set first column as a default sort by asc
                "columns": [
                    {
                        "data": "id",
                        "render": function (data, type, row) {
                            return "<label class='mt-checkbox mt-checkbox-single mt-checkbox-outline'><input name='id[]' type='checkbox' class='checkboxes' value='" + data + "'><span></span></label>";
                        }
                    },
                    { "data": "name" },
                    { "data": "phone" },
                    { "data": "description" },
                    {
                        "data": "status",
                        "render": function (data, type, row) {
                            if (data === 1) {
                                return "<span  class='badge  badge-md badge-success'> Active </span>";
                            }
                            else return "<span class='badge  badge-md badge-warning'> Blocked </span>";
                        }
                    },
                    {
                        "data": "updatedTime",
                        "render": function (data, type, row) {
                            if (data)
                                return window.moment(data).format("DD/MM/YYYY");
                            else
                                return null;
                        }
                    },
                    {
                        "data": "createdTime",
                        "render": function (data, type, row) {
                            if (data)
                                return window.moment(data).format("DD/MM/YYYY");
                            else
                                return null;
                        }
                    },
                    {
                        "data": function (o) {
                            return "<button class='btn btn-danger btn-remove' data-id='" + o.id + "' ' onclick='contactController.removeData(" + o.id + ")'><i class='fa fa-remove'></i></button> "
                                ;
                        }, "orderable": false
                    }
                ]


            }
        });

        // handle group actionsubmit button click
        //grid.getTableWrapper().on('click', '.table-group-action-submit', function (e) {
        //    e.preventDefault();
        //    var action = $(".table-group-action-input");
        //    if (action.val() != "" && grid.getSelectedRowsCount() > 0) { 
        //        grid.setAjaxParam("customActionType", "group_action");
        //        grid.setAjaxParam("id", grid.getSelectedRows());
        //        grid.getDataTable().ajax.reload();
        //        grid.clearAjaxParams();
        //    } else if (action.val() == "") {
        //        App.alert({
        //            type: 'danger',
        //            icon: 'warning',
        //            message: 'Please select an action',
        //            container: grid.getTableWrapper(),
        //            place: 'prepend'
        //        });
        //    } else if (grid.getSelectedRowsCount() === 0) {
        //        App.alert({
        //            type: 'danger',
        //            icon: 'warning',
        //            message: 'No record selected',
        //            container: grid.getTableWrapper(),
        //            place: 'prepend'
        //        });
        //    }
        //});

        // handle search
        $('#btnSearchName').on('click', function (e) {
            console.log('1213');
            grid.setAjaxParam("searchName", $('#searchName').val());
            grid.getDataTable().ajax.reload();
            grid.clearAjaxParams();
        });


    }

    return {

        //main function to initiate the module
        init: function () {

            initPickers();
            handleRecords();
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "positionClass": "toast-top-center",
                "onclick": null,
                "showDuration": "1000",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };
        }

    };

}();

jQuery(document).ready(function () {
    TableDatatablesAjax.init();
    contactController.init();
});

var contactController = {
    init: function () {
        contactController.registerEvent();
    },
    registerEvent: function () {
        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            contactController.restForm();
        });
        $('#btnSave').off('click').on('click', function () {
            $('.error').text('');
            contactController.saveData();
        });
        //$('.btn-remove').off('click').on('click', function () {
        //    console.log(123);
        //});
    },
    restForm: function () {
        $('#hidID').val('0');
        $('#txtTitle').val('');
        $('#txtAddress').val('');
        $('#txtHotLine').val('');
        $('#txtOpenTime').val('');
    },
    saveData: function () {
        var title = $('#txtTitle').val();
        var hotline = $('#txtHotLine').val();
        var opentime = $('#txtOpenTime').val();
        var address = $('#txtAddress').val();
        var id = parseInt($('#hidID').val());
        var config = {
            Title: title,
            Address: address,
            OpenTime: opentime,
            Id: id,
            HotLine: hotline
        };
        $.ajax({
            url: '/Admin/Config/SavaData',
            data: { Config: config },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    $('#modalAddUpdate').modal('hide');
                    TableDatatablesAjax.init();
                    toastr.success("Cập Nhật Thành Công !!!", "Thông Báo");

                }
                else {
                    let message = response.message;
                    console.log(message);

                    $('.error').text('');

                    if (parseInt(message["config.Title"].errors.length) > 0) {
                        let ex = message["config.Title"].errors[0].exception == null ? '' : message["config.Title"].errors[0].exception;
                        let validater = message["config.Title"].errors[0].errorMessage == null ? '' : message["config.Title"].errors[0].errorMessage;
                        let str = validater + ex;
                        $('.error-Titile').text(str);
                    }

                    if (parseInt(message["config.Address"].errors.length) > 0) {
                        let ex = message["config.Address"].errors[0].exception == null ? '' : message["config.Address"].errors[0].exception;
                        let validater = message["config.Address"].errors[0].errorMessage == null ? '' : message["config.Address"].errors[0].errorMessage;
                        let str = validater + ex;
                        $('.error-Address').text(str);
                    }

                    if (parseInt(message["config.HotLine"].errors.length) > 0) {
                        let ex = message["config.HotLine"].errors[0].exception == null ? '' : message["config.HotLine"].errors[0].exception;
                        let validater = message["config.HotLine"].errors[0].errorMessage == null ? '' : message["config.HotLine"].errors[0].errorMessage;
                        let str = validater + ex;
                        $('.error-HotLine').text(str);
                    }

                    if (parseInt(message["config.OpenTime"].errors.length) > 0) {
                        let ex = message["config.OpenTime"].errors[0].exception == null ? '' : message["config.OpenTime"].errors[0].exception;
                        let validater = message["config.OpenTime"].errors[0].errorMessage == null ? '' : message["config.OpenTime"].errors[0].errorMessage;
                        let str = validater + ex;
                        $('.error-OpenTime').text(str);
                    }

                }
            }

        })

    },
    getIdData: function (id) {
        $('#modalAddUpdate').modal('show');
        $('.error').text('');
        $.ajax({
            url: '/Admin/Config/GetDataID',
            data: {
                id: id
            },
            type: 'Get',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $('#hidID').val(data.id);
                    $('#txtTitle').val(data.title);
                    $('#txtHotLine').val(data.hotLine);
                    $('#txtOpenTime').val(data.openTime);
                    $('#txtAddress').val(data.address);
                }
                else {
                    console.log("lỗi");
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    removeData: function (id) {
        var r = confirm("Are you sure to delete ?");
        if (r == true) {
            $.ajax({
                url: '/Admin/Contact/Delete',
                data: { id: id },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {
                        TableDatatablesAjax.init();
                        toastr.success("Xóa Thành Công !!!", "Thông Báo");

                    }
                    else {
                        toastr.error(data.message, "Thông Báo");

                    }
                }

            })
        }
    },
    changStatus: function (id, data) {
        console.log(data);
    }

}
contactController.init();