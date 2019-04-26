# OpenCV

## Installation

	pip install opencv-python

## Note

* Colorchannels are sorted in Blue, Gree, Red (Not RGB!)
* Coordinate Origin is top-left
* Coordinate arguments are: y-axis, x-axis
* Color Space Limmit (8-Bit Number Limmits)
  * NumPy perform arithmetic with “wrap around” (Modulo-Operations)
  * OpenCV performs clipping (Values below zero are rounded to zero, values above 255 ajusted downward to 255)
* 



## Translation

*pure opencv*

```python
import numpy as np
import argparse
import cv2

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
height, width = image.shape[:2]

cv2.imshow("Original", image)

# translation x, y-axis
tx = 500
ty = -900

# translation matrix
M = np.float32([[1, 0, tx], [0, 1, ty]])

# translate
shifted = cv2.warpAffine(image, M, (height, width))

cv2.imshow("Shifted", shifted)
cv2.waitKey(0)
```



*using imutils*

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
height, width = image.shape[:2]

cv2.imshow("Original", image)

# translation x, y-axis
tx = 500
ty = -900

# translate
shifted = imutils.translate(image, tx, ty)

cv2.imshow("Shifted", shifted)
cv2.waitKey(0)
```



## Rotation

*pure opencv*

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]
center = (w/2, h/2)


cv2.imshow("Original", image)
rotation_degree = 45
scale = 1.0
M = cv2.getRotationMatrix2D(center, rotation_degree, scale)
print(M)
rotated = cv2.warpAffine(image, M, (w, h))

cv2.imshow("Shifted", rotated)
cv2.waitKey(0)
```



*with imutils*

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]
center = (w/2, h/2)


cv2.imshow("Original", image)
rotated = imutils.rotate(image, angle=45, center=None, scale=1.0)

cv2.imshow("Shifted", rotated)
cv2.waitKey(0)
```



## Rotation

*pure opencv*

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]
center = (w/2, h/2)

cv2.imshow("Original", image)

# config
new_width = 600
aspect_ratio = new_width / w
dim = (new_width, int(h * aspect_ratio))

resized = cv2.resize(image, dim, interpolation = cv2.INTER_AREA)

cv2.imshow("manipulated", resized)
cv2.waitKey(0)
```



*width imutils*

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]
center = (w/2, h/2)

cv2.imshow("Original", image)

resized = imutils.resize(image, width=500)

cv2.imshow("manipulated", resized)
cv2.waitKey(0)
```



## Flip

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]

# MANIPULATION START
FLIP_X = 1
FLIP_Y = 0
FLIP_XY = -1

result = cv2.flip(image, FLIP_X)
# MANIPULATION END

cv2.imshow("Original", image)
cv2.imshow("manipulated", result)
cv2.waitKey(0)
```



## Crop

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]

# MANIPULATION START
result = image[300:600, 600:1000]
# MANIPULATION END

cv2.imshow("Original", image)
cv2.imshow("manipulated", result)
cv2.waitKey(0)
```

## Smoothing / Blurring

(convolution) kernel is used for calculating pixel values. Kernel size is `k x k` and is an odd number which enables to have a center.
$$
\text{kernel } = k * k
$$


```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]

# MANIPULATION START
result = np.hstack([
    cv2.blur(image, (3,3)),
    cv2.blur(image, (11,11)),
    cv2.blur(image, (101,101))
])
# MANIPULATION END

cv2.imshow("Original", image)
cv2.imshow("manipulated", result)
cv2.waitKey(0)
```



Types of smoothing/blurring

* standard: Calculate average of kernel
* Gaussian: Neighborhood has more weight. Is more naturally. 
  * `cv2.GaussianBlur(image, (k,k), a)`
  * k = kernal size, odd number
  * a = deviation in x-axis, default: 0 for calculate autom.
* Median: Popular for removing salt + pepper. Median-Value of kernel will used as replacement
  * `cv2.medianBlur(image, k)`
* Bilateral Blur: Slower than others but more appropriate for reducing noises but preserving edges
  * Uses two different Gaussian. First gaussian consider only spatial neighbors. The second gaussian consider only pixels with similar intensity
  * `cv2.bilateralFilter(image, pixelNeighborhoodDiameter, colorTolerance, distanceTolerance)`

See also <https://homepages.inf.ed.ac.uk/rbf/HIPR2/gsmooth.htm>



Gaussian: Neigborhood 

![gaussian matrix](https://homepages.inf.ed.ac.uk/rbf/HIPR2/figs/gausmask.gif)



## Edge Detection

Target dtype is float64 because we otherwise miss some edge transition - especially white-to-black

### Laplacian

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]

# MANIPULATION START
image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

# target dtype is float64 because we otherwise miss some edge transition - especially white-to-black
result = cv2.Laplacian(image, cv2.CV_64F)
result = np.uint8(np.absolute(result))
# MANIPULATION END

cv2.imshow("Original", image)
cv2.imshow("manipulated", result)
cv2.waitKey(0)
```



### Sobel

`cv2.Sobel(image, cv2.CV_64F, orderOfDerivativeX, orderOfDerivativeY)`

```python
sobelX = cv2.Sobel(image, cv2.CV_64F, 1, 0)
sobelY = cv2.Sobel(image, cv2.CV_64F, 0, 1)

sobelX = np.uint8(np.absolute(sobelX))
sobelY = np.uint8(np.absolute(sobelY))

sobelCombined = cv2.bitwise_or(sobelX, sobelY)
cv2.imshow("Sobel X", sobelX)
cv2.imshow("Sobel Y", sobelY)
cv2.imshow("Sobel Combined", sobelCombined)
```

### Canny

![canny sample](sphx_glr_plot_hysteresis_001.png)

([source](https://scikit-image.org/docs/dev/_images/sphx_glr_plot_hysteresis_001.png))



1. Converting to gray image
2. Gaussian Bluring
3. Using Canny
   1. All values below `THRESHOLD_NO_EDGE` don't belongs to edges
   2. All values about `THRESHOLD_EDGE` belongs to edges
   3. All values between belongs to edges if they are connected to edges

```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]

# MANIPULATION START
image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY) # convert to gray
image = cv2.GaussianBlur(image, (5,5), 0) # bluring
THRESHOLD_NO_EDGE, THRESHOLD_EDGE = 30, 150
result = cv2.Canny(image, 30, 150)
# MANIPULATION END

cv2.imshow("Original", image)
cv2.imshow("manipulated", result)
cv2.waitKey(0)
```



## Contours

* Curves in the images are called contours.
* A contour is a curve of points, with no gaps in the curve. Is useful for shape approximation and analysis.
* Requires binarization of image (e.g. Canny Edge Detector)



```python
import numpy as np
import argparse
import cv2
import imutils

ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

image = cv2.imread(args["image"])
h, w = image.shape[:2]

# MANIPULATION START
k = 17
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY) # convert to gray
gray = cv2.GaussianBlur(gray, (k,k), 0) # bluring

THRESHOLD_NO_EDGE, THRESHOLD_EDGE = 30, 150
result = cv2.Canny(gray, THRESHOLD_NO_EDGE, THRESHOLD_EDGE)
(cnts, _) = cv2.findContours(result.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
print(f"found shape {len(cnts)}")

# contourIdx = -1 -> all
cv2.drawContours(image, cnts, contourIdx = -1, color = (0,255,0), thickness=6)
# MANIPULATION END

cv2.imshow("Original", image)
cv2.imshow("manipulated", result)
cv2.waitKey(0)
```



## Paper Scanner Example

Parameters to ajust: 

* Gaussian Blur Kernal Size
* Canny Thresholds

```python
import numpy as np
import argparse
import cv2
import imutils

def order_points(pts):
	# initialzie a list of coordinates that will be ordered
	# such that the first entry in the list is the top-left,
	# the second entry is the top-right, the third is the
	# bottom-right, and the fourth is the bottom-left
	rect = np.zeros((4, 2), dtype = "float32")

	# the top-left point will have the smallest sum, whereas
	# the bottom-right point will have the largest sum
	s = pts.sum(axis = 1)
	rect[0] = pts[np.argmin(s)]
	rect[2] = pts[np.argmax(s)]

	# now, compute the difference between the points, the
	# top-right point will have the smallest difference,
	# whereas the bottom-left will have the largest difference
	diff = np.diff(pts, axis = 1)
	rect[1] = pts[np.argmin(diff)]
	rect[3] = pts[np.argmax(diff)]

	# return the ordered coordinates
	return rect

def four_point_transform(image, pts):
	# obtain a consistent order of the points and unpack them
	# individually
	rect = order_points(pts)
	(tl, tr, br, bl) = rect

	# compute the width of the new image, which will be the
	# maximum distance between bottom-right and bottom-left
	# x-coordiates or the top-right and top-left x-coordinates
	widthA = np.sqrt(((br[0] - bl[0]) ** 2) + ((br[1] - bl[1]) ** 2))
	widthB = np.sqrt(((tr[0] - tl[0]) ** 2) + ((tr[1] - tl[1]) ** 2))
	maxWidth = max(int(widthA), int(widthB))

	# compute the height of the new image, which will be the
	# maximum distance between the top-right and bottom-right
	# y-coordinates or the top-left and bottom-left y-coordinates
	heightA = np.sqrt(((tr[0] - br[0]) ** 2) + ((tr[1] - br[1]) ** 2))
	heightB = np.sqrt(((tl[0] - bl[0]) ** 2) + ((tl[1] - bl[1]) ** 2))
	maxHeight = max(int(heightA), int(heightB))

	# now that we have the dimensions of the new image, construct
	# the set of destination points to obtain a "birds eye view",
	# (i.e. top-down view) of the image, again specifying points
	# in the top-left, top-right, bottom-right, and bottom-left
	# order
	dst = np.array([
		[0, 0],
		[maxWidth - 1, 0],
		[maxWidth - 1, maxHeight - 1],
		[0, maxHeight - 1]], dtype = "float32")

	# compute the perspective transform matrix and then apply it
	M = cv2.getPerspectiveTransform(rect, dst)
	warped = cv2.warpPerspective(image, M, (maxWidth, maxHeight))

	# return the warped image
	return warped


ap = argparse.ArgumentParser()
ap.add_argument("-i ", "--image", required=True, help = "Path to the image")
args = vars(ap.parse_args())

resize_height = 800
image = cv2.imread(args["image"])
h, w = image.shape[:2]
ratio = h / resize_height
orig = image.copy()
image = imutils.resize(image, height=resize_height)

k = 3
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
gray = cv2.GaussianBlur(gray, (k,k), 0)
edged = cv2.Canny(gray, 75, 200)

cnts = cv2.findContours(edged.copy(), cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)
cnts = imutils.grab_contours(cnts)
cnts = sorted(cnts, key = cv2.contourArea, reverse = True)[:5]

print("found %d" % len(cnts))
i = 1
for c in cnts:
    i += 1
    peri = cv2.arcLength(c, True)
    approx = cv2.approxPolyDP(c, 0.02 * peri, True)

    if len(approx) == 4:
        screenCnt = approx
        cv2.drawContours(image, [screenCnt], -1, (0,255,0), 2)
        (x, y, w, h) = cv2.boundingRect(approx)
        vertices = approx[:,0,:]
        #rect = image[y:y+h, x:x+w]
        #cv2.imshow(f"Rect {i}", rect)
        cv2.imshow("contour %d" % i, four_point_transform(image, vertices))
        #break
    else:
        cv2.drawContours(image, [approx], -1, (0,0,255), 2)

cv2.imshow("image", image)
cv2.imshow("edged", edged)
cv2.waitKey(0)
cv2.destroyAllWindows()
```

