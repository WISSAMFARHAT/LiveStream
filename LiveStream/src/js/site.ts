//const video = document.getElementById('video') as HTMLVideoElement;


//if (video) {
//    fetch('https://manar.live/iptv/playlist.m3u8')
//        .then(response => response.text())
//        .then(data => {

//            // Create a MediaSource object
//            var mediaSource = new MediaSource();
//            video.src = URL.createObjectURL(mediaSource);

//            mediaSource.addEventListener('sourceopen', function () {
//                var sourceBuffer = mediaSource.addSourceBuffer('video/mp4; codecs="avc1.42E01E,mp4a.40.2"');
//                sourceBuffer.appendBuffer(new TextEncoder().encode(data));
//                video.play();
//            }
//            );
//        });

//    video.addEventListener('play', function () {
//        console.log('Video started playing');
//    });
//    video.addEventListener('pause', function () {
//        console.log('Video paused');
//    });
//    video.addEventListener('error', function () {
//        console.error('Error playing video');
//    });
//}






