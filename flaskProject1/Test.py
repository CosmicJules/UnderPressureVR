import unittest
from app import app

#This file is used for two unit tests

class MyTestCase(unittest.TestCase):
    def test_getheartrate_response(self):
        tester = app.test_client(self)
        response = tester.get('/?H=69&D=2021-04-26%2015:17:13', content_type = 'json')
        self.assertEqual(response.status_code,200)

    def test_return_response(self):
        tester = app.test_client(self)
        response = tester.get('/return', content_type = 'json')
        self.assertEqual(response.status_code,200)


if __name__ == '__main__':
    unittest.main()
