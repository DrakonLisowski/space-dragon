const readline = require("readline");

const mapWidth = 48;
const mapHeight = 16;
const sectorSize = 4;
const verticalSectors = mapHeight / sectorSize;
const horizontalSectors = mapWidth / sectorSize;
const sectorDensity = 0.09;
const delta = 1;

const stars = [];

for (let i = 0; i < mapHeight; i++) {
  stars[i] = [];
  for (let j = 0; j < mapWidth; j++) {
    stars[i][j] = 0;
  }
}

function getRandomInt(max) {
  return Math.floor(Math.random() * Math.floor(max));
}

function getRandomIntRange(min, max) {
  return  min + getRandomInt(max - min);
}

function fillSpaceWithStars(xStart, yStart, xEnd, yEnd) {
  const sectorSpace = (xEnd - xStart) * (yEnd - yStart);
  const starCountMin = Math.max(1, Math.ceil(sectorDensity * sectorSpace) - delta);
  const starCountMax = Math.ceil(sectorDensity * sectorSpace) + delta;
  const starCountMine = getRandomIntRange(starCountMin, starCountMax);

  for (let i = 0; i < starCountMine; i++) {
    const coordX = getRandomIntRange(xStart, xEnd);
    const coordY = getRandomIntRange(yStart, yEnd);
    stars[coordY][coordX] = 1;
  }
}

for (let i = 0; i < verticalSectors; i++) {
  for (let j = 0; j < horizontalSectors; j++) {
    fillSpaceWithStars(
      j * sectorSize,
      i * sectorSize,
      (j + 1) * sectorSize - 1,
      (i + 1) * sectorSize - 1
    )
  }
}

for (let i = 0; i < mapHeight; i++) {
  let visualLine = '';
  for (let j = 0; j < mapWidth; j++) {
    visualLine += stars[i][j] ? '0' : ' '
  }
  console.log(visualLine);
}
