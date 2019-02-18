# Sound Card ECG
The **Sound Card ECG** program provides a simple interface to view and measure ECG signals obtained through the sound card (using a line-in or microphone jack).

![](src/SoundCardECG/screenshot.png)

This is my heartbeat rate as I comfortably used the computer, then took a few minutes to watch a scary video (which elevated my heartrate for a few minutes in the middle).

## Download Binary (SoundCardECG.exe)
Click-to-run binaries are provided with each release:\
https://github.com/swharden/SoundCardECG/releases

## Hardware

### AD8232 ECG Module
My preferred ECG device (and the one I used in the screenshot) is a [AD8232](https://www.analog.com/media/en/technical-documentation/data-sheets/ad8232.pdf) breakout board ([SparkFun](https://www.sparkfun.com/products/12650)) feeding the signal directly into the microphone jack of my PC.

<img src='https://github.com/swharden/SoundCardECG/blob/master/graphics/sound-card-ecg-AD8232.jpg' width='400'>

### DIY ECG with 1 Op-Amp
Those interested in building an ECG circuit from scratch may find my [DIY ECG with a Single Op-Amp](https://github.com/swharden/diyECG-1opAmp) (an LM-741) project interesting.

<img src='https://github.com/swharden/diyECG-1opAmp/blob/master/circuit/circuit.jpg' width='400'>

### Lead Placement
<img src='https://github.com/swharden/SoundCardECG/blob/master/graphics/ecg-lead-placement.png' width='400'>
