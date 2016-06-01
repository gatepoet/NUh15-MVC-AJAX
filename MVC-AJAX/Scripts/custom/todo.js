$(function () {
    var Item = function (item) {
        this.id = item.id;
        this.title = ko.observable(item.title);
        this.completed = ko.observable(item.completed);
    };
    var vm = {
        title: ko.observable(),
        newItemTitle: ko.observable(),
        items: ko.observableArray(),
        addItem: function (vm, e) {
            var json = {
                title: vm.newItemTitle(),
                completed: false
            };
            vm.newItemTitle("");
            $.post('/api/todo', json)
                .done(function (data) {
                    vm.items.push(new Item(data));
                });
        },
        completeItem: function (item, e) {

            item.completed(true);
            var json = ko.toJSON(item);
            $.ajax('/api/todo/' + item.id, {
                data: json,
                contentType: "application/json",
                method: "PUT"
            }).done(function (data) {
                console.log(data);
            }).fail(function (error) {
                item.completed(false);
                console.error(data);
            });
        }
    };
    ko.applyBindings(vm);

    $.get('/api/todo')
        .done(function (data) {
            for (var i = 0; i < data.length; i++) {
                vm.items.push(new Item(data[i]));
            }
        });
});