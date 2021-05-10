from flask import Flask
from flask import Flask, render_template, json, request, url_for, jsonify

app = Flask(__name__)
HR = []

#This route is used to input the information, will only show one heart rate value, which will be the one input from the URL. Used primarily by the android application
@app.route('/',methods=['GET', 'POST'])
def getheartRate():

    heartrate = request.args['H']
    DT = request.args['D']

    HR.append(DT)
    HR.append(heartrate)

    print(json.dumps(HR))
    return heartrate

#This route is used to show all heart rate and temporal values. Used primarily by the Unity application to retrieve the data
@app.route('/return',methods=['GET', 'POST'])
def returnheartRate():

    keys = []
    values = []
    for i, j in enumerate(HR):
        if i % 2 == 0:
            keys.append(j)
        else:
            values.append(j)

    y = dict(zip(keys, values))
    y = json.dumps(y)
    return y
