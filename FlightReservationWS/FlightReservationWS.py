from flask import Flask, request, abort
import json
import sqlite3
from datetime import datetime

app = Flask(__name__)

conn = sqlite3.connect("flights.db")

@app.route('/flights/available', methods=['GET'])
def get_available_flights():
	try:
		departure = request.args['departure']
		arrival = request.args['arrival']
		res_json = get_flight_from_bdd(departure, arrival)
		return res_json
	except Exception as e:
		print(str(e))
		abort(400)


def get_flight_from_bdd(departure, arrival):
	cursor = conn.cursor()
	res = []
	for row in cursor.execute('select * from available where villeDepart=? and villeArrivee=?;', (departure, arrival)):
		res.append(row)
	cursor.close()
	return json.dumps(res)

@app.route('/flights/cities/departure', methods=['GET'])
def list_cities_departure():
	try:
		cursor = conn.cursor()
		res = []
		for row in cursor.execute('select villeDepart from available;'):
			res.append(row)
		return json.dumps(res)
	except:
		print(str(e))
		abort(400)

@app.route('/flights/cities/arrival', methods=['GET'])
def list_cities_arrival():
	try:
		cursor = conn.cursor()
		res = []
		for row in cursor.execute('select villeArrivee from available;'):
			res.append(row)
		return json.dumps(res)
	except:
		print(str(e))
		abort(400)

@app.errorhandler(400)
def bad_request_handler(error):
	return ("400 Bad Request Error : " + str(error)), 400


@app.errorhandler(500)
def internal_error_handler(error):
	return ("500 Internal Error :" + str(error)), 500


if __name__ == '__main__':
	app.run()
