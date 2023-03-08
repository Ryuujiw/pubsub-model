# pubsub-model

This solution demonstrates a publisher subscriber model.

There are 2 web projects in this solution:
1. Sitecore
2. Abc.Accounting

Sitecore acts as a publisher while Abc.Accounting acts as a subscriber.
[![](https://mermaid.ink/img/pako:eNptz8EKwjAMBuBXKbm6CV57GAy9iajs2kvXhq1oU22bg4y9ux1jB8GcQvL9kExggkWQkPDNSAZPTg9Re0WiVOcymhCxbprdBVPSA4o7I6MUN-6fLo2r-9kteAtKcT3_I8XUbW_2rTGBKTsaDlIcAyX2CBV4jF47W86alrSCPKJHBbK0VseHAkVzcZpz6D5kQObIWAG_rM7bC-tw_gJ9vUvy?type=png)](https://mermaid.live/edit#pako:eNptz8EKwjAMBuBXKbm6CV57GAy9iajs2kvXhq1oU22bg4y9ux1jB8GcQvL9kExggkWQkPDNSAZPTg9Re0WiVOcymhCxbprdBVPSA4o7I6MUN-6fLo2r-9kteAtKcT3_I8XUbW_2rTGBKTsaDlIcAyX2CBV4jF47W86alrSCPKJHBbK0VseHAkVzcZpz6D5kQObIWAG_rM7bC-tw_gJ9vUvy)

To publish a message, a POST request is made to /Orders endpoint of the publisher.

Sample request body:
![image](https://user-images.githubusercontent.com/32730247/223728337-c2b04040-fc23-44e0-bae4-3695603ce404.png)

Sample curl:
```
curl -X 'POST' \
  'https://localhost:7156/Orders' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '"somedata"'
```

Once the message is published, the subscriber can view the latest published message via the /orders/get-latest endpoint

Sample curl:
```
curl https://localhost:44379/orders/get-latest
```

Response:
```
{"orderId":"b0770dd4-fa49-444b-9e39-9fa40685cdac","remarks":"somedata"}
```
