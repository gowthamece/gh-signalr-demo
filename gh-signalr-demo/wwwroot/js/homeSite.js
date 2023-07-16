const InitializeSignalRConnection = () => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/farmhub").build();

    connection.on("ReceiveNewTemperature", ({ farmId, newTemperature }) => {
        const tr = document.getElementById(farmId + "-tr");
        const input = document.getElementById(farmId + "-input");
        //start animation
        tr.classList.add("animate-highlight");
        setTimeout(() => tr.classList.remove("animate-highlight"), 2000);

        //const bidText = document.getElementById(farmId + "-bidtext");
        //bidText.innerHTML = newTemperature;
        input.value = newTemperature;
    });

    connection.start().catch((err) => {
        return console.error(err.toString());
    });

    return connection;
}

const connection = InitializeSignalRConnection();

const submitFarmid = (farmId) => {
    const temp = document.getElementById(farmId + "-input").value;
    fetch("/farm/" + farmId + "/farmTemp?farmTemp=" + temp, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        }
    });
    connection.invoke("NotifyNewTemperature", { farmId: parseInt(farmId), newTemperature: parseInt(temp) });
}
