var jsFunctions = {};

jsFunctions.calculateSquareRoot = function () {
  const number = prompt("Enter your number");

  DotNet.invokeMethodAsync("BlazorHostedIdentity.Client", "CalculateSquareRoot", parseInt(number))
    .then(result => {
      var el = document.getElementById("string-result");
      el.innerHTML = result;
    });
}

jsFunctions.calculateSquareRootWithJustResult = function () {
  const number = prompt("Enter your number");

  DotNet.invokeMethodAsync("BlazorHostedIdentity.Client", "CalculateSquareRootWithJustResult", parseInt(number), true)
    .then(result => {
      var el = document.getElementById("result");
      el.innerHTML = result;
    });
}

jsFunctions.showMouseCoordinates = function (dotNetObjRef) {
  dotNetObjRef.invokeMethodAsync("ShowCoordinates", {
    x: window.event.screenX,
    y: window.event.screenY
  });
}

jsFunctions.registerMouseCoordinatesHandler = function (dotNetObjRef) {
  function mouseCoordinatesHandler() {
    dotNetObjRef.invokeMethodAsync("ShowCoordinates", {
      x: window.event.screenX,
      y: window.event.screenY
    });
  };

  mouseCoordinatesHandler();

  document.getElementById("coordinates").onmousemove = mouseCoordinatesHandler;
}

jsFunctions.registerOnlineStatusHandler = function (dotNetObjRef) {
  function onlineStatusHandler() {
    dotNetObjRef.invokeMethodAsync("SetOnlineStatusColor", navigator.onLine);
  };

  onlineStatusHandler();
  window.addEventListener("online", onlineStatusHandler);
  window.addEventListener("offline", onlineStatusHandler);
}