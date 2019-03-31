define(function () {
    return class FileHandler {
        uploadFile(elemantId, jsonPreviewElementId, callback) {
            clearInterval(this.fileSubmitScheduler)
            let files = document.getElementById(elemantId).files
            if (files.length > 0) {
                this.fileSubmitScheduler = this.setIntervalImmediately(function () {
                    let formData = new FormData();
                    formData.append("dataFile", files[0]);
                    let xhr = new XMLHttpRequest();
                    xhr.onload = function () {
                        //should check for a valid status code here

                        document.getElementById(jsonPreviewElementId).innerHTML = this.response
                        let data = JSON.parse(this.response)
                        if (callback) {
                            callback(data)
                        }
                    }
                    xhr.open("POST", "api/datafiles/upload");
                    xhr.send(formData);
                }, 60 * 1000);  //every 60 seconds
            }
        }
        setIntervalImmediately(func, interval) {
            func();
            return setInterval(func, interval);
        }
    }
})