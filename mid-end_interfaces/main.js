const http = require('http');
const fs = require('fs');
var qs = require('querystring');

const server = http.createServer((request, response) => {

	if (request.method === "GET") {

		const data = fs.readFileSync("get.txt", 'utf8');
		response.write(data);
		response.end();

	} else if (request.method === "POST") {

		var incoming = '';
		var rcv_index = '';

		request.on('data', chunk => {
			incoming += chunk.toString();
		});
		request.on('end', () => {
			rcv_index = incoming.slice(-2);
		});

		setTimeout(function() {
			const { spawn } = require("child_process");
			const pythonProcess = spawn('python',["recommended.py", rcv_index]);
		}, 750); // executes after 750 ms

		response.write('1');
		response.end();

	}

	console.log("HTTP " + request.method);
	setTimeout(function() {
		if (request.method === "POST") { console.log("index: " + rcv_index); }
	}, 750);

});

server.listen(3000, "0.0.0.0");