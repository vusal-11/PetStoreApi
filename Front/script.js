

async function GetWeatherData(){

    var res = await fetch('https://localhost:7203/WeatherForecast',{'method':'GET'});

    return res;

}


document.addEventListener('DOMContentLoaded',async ()=>{

    var json = await GetWeatherData();
    console.log(json);

});