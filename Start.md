# Live Streaming

## Introduction

This report outlines the development process of an online live streaming project using ASP.NET MVC, the public link URL (.m3u8) and the video.js library to convert the link to a media player for use in an HTML video tag. The project was later updated to use only JavaScript, specifically TypeScript.

## Background

The goal of the project was to create an online live streaming platform that would allow users to watch a public channel. The project used ASP.NET MVC to create a web application that would display the live stream.

## Video.js Implementation

First add the link in the header:

https://vjs.zencdn.net/8.0.4/video-js.css <br />
https://vjs.zencdn.net/8.0.4/video.min.js

and in html use this:

```html
<video id="my-video" class="video-js" controls preload="auto" data-setup="{}">
  <source src="LinkUrl" type="application/x-mpegURL" />
</video>
```

## JavaScript Implementation

Later, the project was updated to use only JavaScript to use my own video tag component, specifically Typescript. The following code was used to accomplish this:

```typescript
// TypeScript code without video.js library
const video = document.querySelector("#video") as HTMLVideoElement;
if (video) {
  fetch('https://example.com/stream.m3u8') //link url (.m3u8) live streaming
    .then(response => response.text())
    .then(m3u8 => {
      const baseUrl = 'https://example.com/';
      const urls = m3u8.match(/chunklist_.+\.m3u8/g);
      const promises = urls.map(url => fetch(baseUrl + url).then(response => response.text()));
      return Promise.all(promises);
    })
    .then(chunklists => {
      const tsUrls = chunklists.flatMap(chunklist => chunklist.match(/.+\.ts/g));
      const promises = tsUrls.map(url => fetch(url).then(response => response.text()));
      return Promise.all(promises);
    })
    .then(async blobs => {
      const concatenatedBlob = new Blob(await blobs, { type: 'application/x-mpegURL' });
      const videoUrl = URL.createObjectURL(concatenatedBlob);

      const source = document.createElement('source');
      source.src = videoUrl;
      source.type = 'application/x-mpegURL';

      video.appendChild(source);

      video.play();
    });
}
```

This code used the fetch() method to retrieve the public link URL and extract the .ts video chunks from the .m3u8 playlist. The video chunks were then concatenated into a single blob and used to create a new video URL, which was then set as the src attribute of a new source element that was appended to the video element.
