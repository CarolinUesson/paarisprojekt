$(".selectItems2").each(function () {
    var $this = $(this),
        selectedId = $this.data('id'),
        controller = $this.data('controller');

    $this.select2({
        placeholder: `Select value: controller=${controller}; id=${selectedId}`,
        theme: "bootstrap4",
        allowClear: true,
        ajax: {
            url: `/${controller}/selectItems`,
            data: function (params) {
                var query = {
                    researchString: params.term,
                    id: selectedId
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.value,
                            text: item.text,
                            selected: item.selected
                        };
                    }),
                };
            }
        }
    });
});