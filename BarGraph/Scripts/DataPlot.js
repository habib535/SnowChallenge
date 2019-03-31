define(['./highcharts'], function (Highcharts) {
    return class DataPlot {
        draw(data, chartContainerId) {
            let processed_json = new Array()
            for (let i = 0; i < data.length; i++) {
                processed_json.push([data[i].Name, data[i].Size]);
            }
            Highcharts.chart(chartContainerId, {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Bar chart info'
                },
                xAxis: {
                    type: 'category',
                    title: {
                        text: ""
                    }
                },
                yAxis: {
                    title: {
                        text: "Size"
                    }
                },
                credits: {
                    enabled: false
                },
                series: [{
                    name: 'Color',
                    data: processed_json
                }]
            });
        }
    }
})