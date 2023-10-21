$(document).ready(() => {
    getCategory();
    getProduct();
});
var getCategory = () => $.ajax({
    url: `http://localhost:5276/api/Category`,
    type: "GET",
    headers: {
        "Content-Type": "application/json",
    },
    success: (data) => loadDataOptions(data),
    error: () => { alert("Error") },
});

const loadDataOptions = (data) => {
    data.forEach(element => {
        $("#option").append(`<option selected value="${element.categoryName}" >${element.categoryName}</option>`)
    });
}

const getProduct = () => $.ajax({
    url: `http://localhost:5276/api/Product`,
    type: "GET",
    headers: {
        "Content-Type": "application/json",
    },
    success: (data) => loadDataTable(data),
    error: () => { alert("Error") },
});

const loadDataTable = (data) => {
    $("#table").empty();
    data.forEach(element => {
        const json = JSON.stringify(element);
        var html = `
       <tr>
       <td>${element.productId}</td>
       <td>${element.productName}</td>
       <td>${element.unitPrice}</td>
       <td>${element.unitsInStock}</td>
       <td>${element.image}</td>
       <td>${element.categoryId}</td>
       <td id="${element.productId}">
        <button onclick="deleteProduct(${element.productId})" type="button" class="btn btn-outline-dark">Delete</button>
        <button onclick='detailProduct(${JSON.stringify(element)})' type="button" class="btn btn-outline-dark">Detail</button>
        </td>
        </tr>
       `;
        $("#table").append(html);
    });
}


const createProduct = () => $.ajax({
    url: `http://localhost:5276/api/Product`,
    type: "POST",
    headers: {
        "Content-Type": "application/json",
    },
    data: JSON.stringify({
        productName: $('#ProductName').val(),
        unitPrice: $('#UnitPrice').val(),
        unitsInStock: $('#UnitsInStock').val(),
        image: $('#Image').val(),
        categoryId: $('#CategoryId').val(),
    }),
    success: () => getProduct(),
    error: () => { alert("Error") },
});

const updateProduct = (id) => $.ajax({
    url: `http://localhost:5276/api/Product`,
    type: "POST",
    headers: {
        "Content-Type": "application/json",
    },
    data: JSON.stringify({
        productId: $('#ProductId').val(),
        productName: $('#ProductName').val(),
        unitPrice: $('#UnitPrice').val(),
        unitsInStock: $('#UnitsInStock').val(),
        image: $('#Image').val(),
        categoryId: $('#CategoryId').val(),
    }),
    success: () => getProduct(),
    error: () => { alert("Error") },
});


const deleteProduct = (id) => $.ajax({
    url: `http://localhost:5276/api/Product?productId=${id}`,
    type: "DELETE",
    headers: {
        "Content-Type": "application/json",
    },
    success: () => getProduct(),
    error: () => { alert("Error") },
});

const detailProduct = (element) => {
    $('#ProductId').val(element.productId),
        $('#ProductName').val(element.productName),
        $('#UnitPrice').val(element.unitPrice),
        $('#UnitsInStock').val(element.unitsInStock),
        $('#Image').val(element.image),
        $('#CategoryId').val(element.categoryId);
}

