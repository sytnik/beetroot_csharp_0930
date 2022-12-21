document.addEventListener("DOMContentLoaded", () => {
    declareVariables()
    var input = document.getElementById("addElem");
    input.onmouseleave = function()
    {
        var elem = document.getElementById("list1")
        var newLi = document.createElement("li")
        newLi.appendChild(
            document.createTextNode(input.value))
        newLi.setAttribute("style", "color: red; cursor: progress;")
        newLi.addEventListener("click", function () {
            if(confirm("do you want to delete?"))
                        newLi.remove()
        })
        elem.appendChild(newLi)
    }
});


function onclick3(id) {
    alert(`button ${id} clicked`)
}

function declareVariables() {
    var elem = document.getElementById("list1")
    var ints = [1, 2, 3, 4, 5]
    ints.forEach(e => {
        var newLi = document.createElement("li")
        newLi.appendChild(
            document.createTextNode("item " + e))
        newLi.setAttribute("style", "color: red; cursor: progress;")
        newLi.addEventListener("click", function () {
            if(confirm("do you want to delete?"))
                        newLi.remove()
        })
        elem.appendChild(newLi)
    })

    // const arr = [1, 1.2, true, undefined, null, [1, 3, 5]]
    // var arr2 = arr.concat(5, null, "123")
    // var index = arr.indexOf(null)
    // var isNumber = (e) => e > 0
    // var i2 = arr.findIndex(isNumber)
    // arr.push(12345)
    // console.log(arr)
}
