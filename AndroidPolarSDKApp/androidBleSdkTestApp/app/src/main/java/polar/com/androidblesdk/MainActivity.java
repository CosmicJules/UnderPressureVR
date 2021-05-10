package polar.com.androidblesdk;

import android.Manifest;
import android.nfc.Tag;
import android.os.Build;
import android.os.Bundle;
import android.os.SystemClock;
import android.util.Log;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import org.reactivestreams.Publisher;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Set;
import java.util.UUID;


import io.reactivex.rxjava3.disposables.Disposable;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;

import polar.com.sdk.api.PolarBleApi;
import polar.com.sdk.api.PolarBleApiCallback;
import polar.com.sdk.api.PolarBleApiDefaultImpl;
import polar.com.sdk.api.errors.PolarInvalidArgument;

import polar.com.sdk.api.model.PolarDeviceInfo;

import polar.com.sdk.api.model.PolarHrData;

//This file is taken from the example polar BLE Project in the SDK files. it is used in order to load the necessary functionality from the chest strap.



public class MainActivity extends AppCompatActivity {
    private static final String TAG = MainActivity.class.getSimpleName();
    private static final String API_LOGGER_TAG = "API LOGGER";
    PolarBleApi api;
    Disposable broadcastDisposable;
    Disposable ecgDisposable;
    Disposable accDisposable;
    Disposable gyrDisposable;
    Disposable magDisposable;
    Disposable ppgDisposable;
    Disposable ppiDisposable;
    Disposable scanDisposable;
    String DEVICE_ID = "8BFB8821";
//This device ID is my personal Chest straps ID, this will need to be changed if using a different H10 chest strap

    private TextView mTextViewHR;

    public int globalHR = 0;
    public int index = 1;
    public int lastIndex = 0;

    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        // Notice PolarBleApi.ALL_FEATURES are enabled
        api = PolarBleApiDefaultImpl.defaultImplementation(this, PolarBleApi.ALL_FEATURES);
        api.setPolarFilter(false);

        final Button connect = this.findViewById(R.id.connect_button);
        final Button disconnect = this.findViewById(R.id.disconnect_button);

        mTextViewHR = findViewById(R.id.textView_HR);
        TestMain example = new TestMain();





        api.setApiCallback(new PolarBleApiCallback() {





            @Override
            public void blePowerStateChanged(boolean powered) {
                Log.d(TAG, "BLE power: " + powered);
            }

            @Override
            public void deviceConnected(@NonNull PolarDeviceInfo polarDeviceInfo) {
                Log.d(TAG, "CONNECTED: " + polarDeviceInfo.deviceId);
                DEVICE_ID = polarDeviceInfo.deviceId;

            }

            @Override
            public void deviceConnecting(@NonNull PolarDeviceInfo polarDeviceInfo) {
                Log.d(TAG, "CONNECTING: " + polarDeviceInfo.deviceId);
                DEVICE_ID = polarDeviceInfo.deviceId;
            }

            @Override
            public void deviceDisconnected(@NonNull PolarDeviceInfo polarDeviceInfo) {
                Log.d(TAG, "DISCONNECTED: " + polarDeviceInfo.deviceId);
                ecgDisposable = null;
                accDisposable = null;
                gyrDisposable = null;
                magDisposable = null;
                ppgDisposable = null;
                ppiDisposable = null;
            }

            @Override
            public void streamingFeaturesReady(@NonNull final String identifier,
                                               @NonNull final Set<PolarBleApi.DeviceStreamingFeature> features) {
                for(PolarBleApi.DeviceStreamingFeature feature : features) {
                    Log.d(TAG, "Streaming feature " + feature.toString() + " is ready");

                }

                while(!features.isEmpty())
                    try {
                        if (index!=lastIndex && globalHR!=0)
                        GetURL(example,globalHR);
                        int lastIndex=index;
                        //mTextViewHR.setText(globalHR);
                        SystemClock.sleep(950);
                    } catch (IOException e) {
                        e.printStackTrace();

                    }
            }

            @Override
            public void hrFeatureReady(@NonNull String identifier) {
                Log.d(TAG, "HR READY: " + identifier);
                // hr notifications are about to start
            }

            @Override
            public void disInformationReceived(@NonNull String identifier, @NonNull UUID uuid, @NonNull String value) {
                Log.d(TAG, "uuid: " + uuid + " value: " + value);
            }

            @Override
            public void batteryLevelReceived(@NonNull String identifier, int level) {
                Log.d(TAG, "BATTERY LEVEL: " + level);
            }


            @Override
            public void hrNotificationReceived(@NonNull String identifier, @NonNull PolarHrData data) {


                globalHR=data.hr;
                index++;
                Log.d(TAG, "HR value: " + globalHR);



                //
                //mTextViewHR.setText(globalHR);
                //Log.d(TAG, "HR value: " + data.hr + " rrsMs: " + data.rrsMs + " rr: " + data.rrs + " contact: " + data.contactStatus + "," + data.contactStatusSupported);
        }

            @Override
            public void polarFtpFeatureReady(@NonNull String s) {
                Log.d(TAG, "FTP ready");
            }
        });


        connect.setOnClickListener(v -> {
            try {
                api.connectToDevice(DEVICE_ID);
            } catch (PolarInvalidArgument polarInvalidArgument) {
                polarInvalidArgument.printStackTrace();
            }
        });

        disconnect.setOnClickListener(view -> {
            try {
                api.disconnectFromDevice(DEVICE_ID);
            } catch (PolarInvalidArgument polarInvalidArgument) {
                polarInvalidArgument.printStackTrace();
            }
        });



        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M && savedInstanceState == null) {
            this.requestPermissions(new String[]{Manifest.permission.ACCESS_FINE_LOCATION}, 1);
        }
    }


    public  void GetURL(TestMain client, int hr) throws IOException {

        // issue the Get request
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        String currentDateTime = dateFormat.format(new Date()); // Find todays date
        client.doGetRequest(hr, currentDateTime);


    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        if (requestCode == 1) {
            Log.d(TAG, "bt ready");
        }
    }

    @Override
    public void onPause() {
        super.onPause();
        api.backgroundEntered();
    }

    @Override
    public void onResume() {
        super.onResume();
        api.foregroundEntered();

    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        api.shutDown();
    }
}
