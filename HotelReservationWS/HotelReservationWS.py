from flask import Flask, request, abort
import json
import sqlite3

app = Flask(__name__)

conn = sqlite3.connect("hotel.db")


@app.route('/hotels/available', methods=['GET'])
def get_available_hotel():
	try:
		city = request.args['city']
		res_json = get_hotels_from_BDD(city)
		return res_json
	except:
		abort(400)


def get_hotels_from_BDD(city):
	cursor = conn.cursor()
	res = []
	for row in cursor.execute('select * from available where ville=?;', (city,)):
		res.append(row)
	cursor.close()
	return json.dumps(res)


@app.errorhandler(400)
def bad_request_handler(error):
	return ("400 Bad Request Error : " + str(error)), 400


@app.errorhandler(500)
def internal_error_handler(error):
	return ("500 Internal Error :" + str(error)), 500


if __name__ == '__main__':
	app.run()
