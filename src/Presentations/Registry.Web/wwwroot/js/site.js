// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var myMap;
var myPolygon;
var color = {
    green: '#00FF00',
    blue: '0066ff99',
    border: '#0000FF'
};

var localize = {
    success : {
        remove: "Полигон успешно удален!",
        save: "Полигон успешно сохранен!",
        changed: "Полигон успешно изменен!",
        load: "Данные успешно загружены!"
    },
    warning: {
        saved: "Данные предыдущего полигоне не сохранены. Они будут автоматически сохранены!"
    }
}

$(window).on('load', function () {

    loadAllPolygons();
});

ymaps.ready(function () {
    myMap = new ymaps.Map('map', {
        center: [55.751574, 37.573856],
        zoom: 9
    }, {
            searchControlProvider: 'yandex#search'
        });
});

function savePolygon() {
    
    var geometry = {
        AreaId: myPolygon.properties.get("areaId"),
        Hint: myPolygon.properties.get("hintContent"),
        Coordinates: JSON.stringify(myPolygon.geometry.getCoordinates())
    };

    $.ajax({
        type: 'POST',
        url: '/Area/InsertPolygon',
        data: {values: JSON.stringify(geometry) },
        success: function (data) {
            DevExpress.ui.notify(localize.success.save, "success");
            myPolygon.editor.stopDrawing();
            myPolygon.editor.stopEditing();
            setPolygon();
        }
    });
}

function saveNotSavedPolygon() {

    var geometry = {
        AreaId: myPolygon.properties.get("areaId"),
        Hint: myPolygon.properties.get("hintContent"),
        Coordinates: JSON.stringify(myPolygon.geometry.getCoordinates())
    };

    myPolygon.editor.stopDrawing();
    myPolygon.editor.stopEditing();

    $.ajax({
        type: 'POST',
        url: '/Area/InsertPolygon',
        data: { values: JSON.stringify(geometry) },
        success: function (data) {
        }
    });
}


function createPolygon(e) {

    var area = e.data;
    
    setPolygon(new ymaps.Polygon([], {
        hintContent: area.Name,
        areaId: area.Id
    }, {
            editorDrawingCursor: "crosshair",
            fillColor: color.green,
            strokeColor: color.border,
            opacity: 0.5,
            strokeWidth: 2
        }));
    
    myMap.geoObjects.add(myPolygon, area.Id);
    
    var stateMonitor = new ymaps.Monitor(myPolygon.editor.state);
    stateMonitor.add("drawing", function (newValue) {
        myPolygon.options.set("strokeColor", newValue ? '#FF0000' : color.border);
    });

    myPolygon.editor.startDrawing();
}

function removePolygon(e) {
    var index = e.data.Id;

    if (index) {
        var polygon = myMap.geoObjects.get(index);
        myMap.geoObjects.remove(polygon);
    }

    DevExpress.ui.notify(localize.success.remove, "success");
}

function updatePolygon(e) {

    DevExpress.ui.notify(localize.success.changed, "success");
}

function selectPolygonOnMap(e) {
    var index = e.data.Id;

    if (index) {
        var polygon = myMap.geoObjects.get(index);
        myMap.setBounds(polygon.geometry.getBounds());
        setTimeout(function () {
            polygon.options.set({ fillColor: color.blue });
            setTimeout(function () {
                polygon.options.set({ fillColor: color.green });
            }, 1000);
        }, 100);
    }
}

function loadAllPolygons() {
    $.ajax({
        type: 'GET',
        url: '/Area/GetPolygons',
        success: function (data) {
            $.each(data.data, function (index, value) {
                addPolygonToMap(value);
            });
            DevExpress.ui.notify(localize.success.load, "success");
        }
    });
}

function addPolygonToMap(geometry) {

    var polygon = new ymaps.Polygon(JSON.parse(geometry.Coordinates), {
        hintContent: geometry.Hint,
        areaId: geometry.AreaId
    }, {
            fillColor: color.green,
            strokeColor: color.border,
            opacity: 0.5,
            strokeWidth: 2
        });

    myMap.geoObjects.add(polygon, geometry.AreaId);
}

function onCreateArea(e) {
    if (myPolygon) {
        window.setTimeout(function () { DevExpress.ui.notify(localize.warning.saved, "warning"); }, 0);
    }
}

//function deleteAreaById(id) {
//    $.ajax({
//        type: 'DELETE',
//        url: '/Area/DeleteArea',
//        data: { key: id },
//        success: function (data) {
//            $("#gridContainer").dxDataGrid("instance").refresh();
//        }
//    });
//}


function setPolygon(polygon) {

    if (myPolygon && polygon) {
        saveNotSavedPolygon();
    }

    myPolygon = polygon;
    var saveBtn = $('#polygonSaveButton');
    
    if (polygon !== undefined)
        saveBtn.dxButton({ visible: true });
    else
        saveBtn.dxButton({ visible: false });
}