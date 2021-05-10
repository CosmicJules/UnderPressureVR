package polar.com.androidblesdk;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.security.KeyManagementException;
import java.security.NoSuchAlgorithmException;
import java.security.cert.CertificateException;

import javax.net.ssl.HostnameVerifier;
import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLSession;
import javax.net.ssl.SSLSocketFactory;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;


//This file is used to send the heart rate data to the Flask Web server
public class TestMain {
    OkHttpClient preconfiguredClient = new OkHttpClient();
    OkHttpClient client = TestMain.trustAllSslClient(preconfiguredClient);
    //client.dispatcher().setMaxRequestsPerHost(50);

    void doGetRequest(int HR, String datetime) throws IOException {
        Request request = new Request.Builder()
                .url("http:/192.168.0.36:5000/?H="+HR+"&D="+datetime)
                .build();
//This function sends the data to the flask application via the address above. It is called every second.
        Response response = null;
        try {
            response = client.newCall(request).execute();
            String resStr = response.body().string();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }



    public static final MediaType JSON
            = MediaType.parse("application/json; charset=utf-8");


    String doPostRequest(String url, String json) throws IOException {
        RequestBody body = RequestBody.create(JSON, json);
        Request request = new Request.Builder()
                .url(url)
                .post(body)
                .build();
        Response response = client.newCall(request).execute();
        return response.body().string();
    }

    /*
     * This is very bad practice and should NOT be used in production.
     */

    //These functions were used to bypass the previous certificate issues, These are now redundant as I use HTTP now, however they do not cause any issues so will stay here in case the server is changed to HTTPS
    //The issue was fixed in the AndroidManifest.xml file (android:usesCleartextTraffic="true")
    private static final TrustManager[] trustAllCerts = new TrustManager[] {
            new X509TrustManager() {
                @Override
                public void checkClientTrusted(java.security.cert.X509Certificate[] chain, String authType) throws CertificateException {
                }

                @Override
                public void checkServerTrusted(java.security.cert.X509Certificate[] chain, String authType) throws CertificateException {
                }

                @Override
                public java.security.cert.X509Certificate[] getAcceptedIssuers() {
                    return new java.security.cert.X509Certificate[]{};
                }
            }
    };
    private static final SSLContext trustAllSslContext;
    static {
        try {
            trustAllSslContext = SSLContext.getInstance("SSL");
            trustAllSslContext.init(null, trustAllCerts, new java.security.SecureRandom());
        } catch (NoSuchAlgorithmException | KeyManagementException e) {
            throw new RuntimeException(e);
        }
    }
    private static final SSLSocketFactory trustAllSslSocketFactory = trustAllSslContext.getSocketFactory();

    public static OkHttpClient trustAllSslClient(OkHttpClient client) {
        OkHttpClient.Builder builder = client.newBuilder();
        builder.sslSocketFactory(trustAllSslSocketFactory, (X509TrustManager)trustAllCerts[0]);
        builder.hostnameVerifier(new HostnameVerifier() {
            @Override
            public boolean verify(String hostname, SSLSession session) {
                return true;
            }
        });
        return builder.build();
    }

}