from app import app
import ssl
# main function to run the application

#Certificates did not fix original issue with cleartext values, they are still loaded in but at the moment serve no purpose
context = ssl.SSLContext()
context.load_cert_chain('cert.pem', 'key.pem')

#App runs here on any cast address and port 5000
if __name__ == '__main__':
    app.run(host='0.0.0.0',port=5000)