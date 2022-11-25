$(document).ready(function () {
    //$("#otherInstituteLabel").hide();
    //$("#otherInstitute").hide();

    var ddlCategory = $('#ddlCategory');
    ddlCategory.append($("<option></option>").val('').html('Select Category'));
    $.ajax({
        url: 'https://localhost:7221/Product/CategoryDdl',
        type: 'GET',
        dataType: 'json',
        success: function (d) {
            console.table(d);
            $.each(d, function (i, category) {
                ddlCategory.append($("<option></option>").val(category.categoryId).html(category.categoryName));
            });
        },
        error: function () {
            alert('Error!');
        }
    });

    //State details by country id

    $("#ddlCategory").change(function () {
        $('#ddlSubcategory').empty();

        const CategoryId = parseInt($(this).val());
        console.log(CategoryId);

        if (!isNaN(CategoryId)) {
            const ddlSubcategory = $('#ddlSubcategory');
            ddlSubcategory.empty();
            ddlSubcategory.append($("<option></option>").val('').html('Please wait ...'));

            $.ajax({
                url: 'https://localhost:7221/Product/SubcategoryDdl/' + CategoryId,
                type: 'GET',
                dataType: 'json',
                //data: { CategoryId: CategoryId },
                success: function (d) {
                    console.table(d);
                    ddlSubcategory.empty(); // Clear the please wait
                    ddlSubcategory.append($("<option></option>").val('').html('Select Sub Category'));
                    $.each(d, function (i, subcategory) {
                        ddlSubcategory.append($("<option></option>").val(subcategory.subCategoryId).html(subcategory.subCategoryName));
                    });
                },
                error: function () {
                    alert('Error!');
                }
            });
        }

    });


    var ddlUnit = $('#ddlUnit');
    ddlUnit.append($("<option></option>").val('').html('Select Unit'));
    $.ajax({
        url: 'https://localhost:7221/Product/UnitDdl',
        type: 'GET',
        dataType: 'json',
        success: function (d) {
            console.table(d);
            $.each(d, function (i, unit) {
                ddlUnit.append($("<option></option>").val(unit.id).html(unit.type));
            });
        },
        error: function () {
            alert('Error!');
        }
    });

    var ddlPrimarySupplier = $('#ddlPrimarySupplier');
    ddlPrimarySupplier.append($("<option></option>").val('').html('Select Primary Supplier'));
    $.ajax({
        url: 'https://localhost:7221/Product/SupplierDdl',
        type: 'GET',
        dataType: 'json',
        success: function (d) {
            console.table(d);
            $.each(d, function (i, primarysupplier) {
                ddlPrimarySupplier.append($("<option></option>").val(primarysupplier.supplierId).html(primarysupplier.supplierName));
            });
        },
        error: function () {
            alert('Error!');
        }
    });

    $("#ddlPrimarySupplier").change(function () {
        $('#ddlSecondarySupplier').empty();

        const SelectedSupplier = parseInt($(this).val());
        console.log(SelectedSupplier);

        if (!isNaN(SelectedSupplier)) {
            const ddlSecondarySupplier = $('#ddlSecondarySupplier');
            ddlSecondarySupplier.empty();
            ddlSecondarySupplier.append($("<option></option>").val('').html('Please wait ...'));
            $.ajax({
                url: 'https://localhost:7221/Product/SupplierDdl',
                type: 'GET',
                dataType: 'json',
                success: function (d) {
                    let newD = d.filter(item => item.supplierId != SelectedSupplier);
                    console.table(newD);
                    ddlSecondarySupplier.empty();
                    ddlSecondarySupplier.append($("<option></option>").val('').html('Select Secondary Supplier'));
                    $.each(newD, function (i, secondarysupplier) {
                        ddlSecondarySupplier.append($("<option></option>").val(secondarysupplier.supplierId).html(secondarysupplier.supplierName));
                    });
                    $(`#ddlSecondarySupplier option[value='${SelectedSupplier}']`).remove();
                },
                error: function () {
                    alert('Error!');
                }
            });
        }
    });


    var ddlTax = $('#ddlTax');
    ddlTax.append($("<option></option>").val('').html('Select Tax Type'));
    $.ajax({
        url: 'https://localhost:7221/Product/TaxDdl',
        type: 'GET',
        dataType: 'json',
        success: function (d) {
            console.table(d);
            $.each(d, function (i, tax) {
                ddlTax.append($("<option></option>").val(tax.taxId).html(tax.name));
            });
        },
        error: function () {
            alert('Error!');
        }
    });
});