const { Kawaii } = require("kawaii-api");

const api = new Kawaii("token");

api.get("gif", "kiss").then((result) => {
        console.log(result);
    });

api.endpoints("gif").then((result) => {
        console.log(result);
    });

// or async/await

const get = async() => {
    const result = await api.get("gif", "kiss");
    console.log(result);
}

const endpoints = async() => {
    const result = await api.endpoints("gif");
    console.log(result);
}