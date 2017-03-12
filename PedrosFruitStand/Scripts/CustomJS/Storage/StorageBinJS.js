function StorageBin() { };


StorageBin.Keys = function (key, value) {
    localStorage.setItem(key, JSON.stringify(value));
}

StorageBin.Get = function (key) {
    var result = localStorage.getItem(key);
    return result;
}