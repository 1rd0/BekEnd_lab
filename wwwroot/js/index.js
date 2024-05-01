var button = document.getElementById("button");
var result = document.getElementById("result");

button.addEventListener("click", async () => {
    try {
        const response = await fetch("/Getdata");
        if (response.ok) {
            const text = await response.text();
            result.innerText = text;
        } else {
            result.innerText = "Failed to fetch data from server";
        }
    } catch (e) {
        result.innerText = e.message;
    }
});