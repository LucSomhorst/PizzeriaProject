@include('includes/navbar')

<section class="bg-white py-8 antialiased dark:bg-gray-900 md:py-16">
  <div class="mx-auto max-w-screen-xl px-4 2xl:px-0">
    <h2 class="text-xl font-semibold text-gray-900 dark:text-white sm:text-2xl">Menu</h2>
    <div class="mt-6 sm:mt-8 md:gap-6 lg:flex lg:items-start xl:gap-8">
      <div class="mx-auto w-full flex-none lg:max-w-2xl xl:max-w-4xl">
        <div class="space-y-6">
          <div class="rounded-lg border border-gray-200 bg-white p-4 shadow-sm dark:border-gray-700 dark:bg-gray-800 md:p-6">
            @foreach ($orders as $order)
              <form method="POST" action="orders/{{$order->id}}">
                      @method('DELETE')
                @csrf
                <input hidden id="id" name="id" value="{{$order->id}}"/>
                <input type="text" hidden="true" id="size" name="size" value="30"/>
                <div class="space-y-4 md:flex md:items-center md:justify-between md:gap-6 md:space-y-0">
                  <a id="orderModalButton" data-modal-target="orderModal" data-modal-toggle="orderModal" class="shrink-0 md:order-1">
                    <svg height="150" width="150" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" 
                        xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 512.001 512.001" xml:space="preserve" fill="#000000">
                        <g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <g> <path style="fill:#FCC062;" d="M7.813,232.448c0-123.971,100.019-224.502,222.948-224.502v224.502H7.813z"></path> <path style="fill:#FCC062;" d="M279.725,55.966c122.929,0,224.2,100.332,224.2,224.097s-100.28,224.25-224.045,224.25 S55.834,404.34,55.834,280.369h223.89V55.966H279.725z"></path> </g> <path style="fill:#C1272D;" d="M40.044,232.448c0-106.261,85.497-192.272,191.758-192.272v192.272H40.044z"></path> <path style="fill:#FBB03B;" d="M63.518,232.448c0-93.76,74.525-168.798,168.285-168.798v168.798H63.518z"></path> <path style="fill:#C1272D;" d="M279.725,87.98c106.261,0,192.187,85.999,192.187,192.083S385.965,472.301,279.88,472.301 S87.849,386.63,87.849,280.369h191.876V87.98z"></path> <path style="fill:#F7931E;" d="M231.803,87.661c-79.175,0-144.274,64.57-144.274,144.787h64.058v7.599 c0,8.84,7.307,16.007,16.148,16.007c8.84,0,16.148-7.166,16.148-16.007v-7.599h47.922V87.661z"></path> <path style="fill:#FBB03B;" d="M279.725,111.99c93.76,0,168.177,75.248,168.177,168.073S372.704,448.289,279.88,448.289 s-168.022-75.203-168.022-167.921h167.866V111.99z"></path> <circle style="fill:#FF1D25;" cx="103.855" cy="184.019" r="16.007"></circle> <path style="fill:#F7931E;" d="M279.725,136.001c79.175,0,144.166,64.499,144.166,144.063S359.444,424.279,279.88,424.279 s-144.011-64.735-144.011-143.91h143.856L279.725,136.001L279.725,136.001z"></path> <g> <circle style="fill:#FF1D25;" cx="391.978" cy="216.032" r="16.007"></circle> <circle style="fill:#FF1D25;" cx="319.95" cy="344.087" r="16.007"></circle> <circle style="fill:#FF1D25;" cx="223.909" cy="416.126" r="16.007"></circle> <circle style="fill:#FF1D25;" cx="167.882" cy="328.086" r="16.007"></circle> <circle style="fill:#FF1D25;" cx="175.883" cy="71.976" r="16.007"></circle> <circle style="fill:#FF1D25;" cx="415.991" cy="384.112" r="16.007"></circle> </g> <g> <rect x="150.508" y="129.364" transform="matrix(-0.7071 -0.7071 0.7071 -0.7071 181.4652 365.9061)" style="fill:#009245;" width="32.013" height="32.013"></rect> <rect x="318.582" y="150.625" transform="matrix(-0.7071 -0.7071 0.7071 -0.7071 453.3521 521.0471)" style="fill:#009245;" width="32.013" height="32.013"></rect> <rect x="142.506" y="385.471" transform="matrix(-0.7071 -0.7071 0.7071 -0.7071 -13.2905 797.451)" style="fill:#009245;" width="32.013" height="32.013"></rect> <rect x="321.319" y="393.489" transform="matrix(-0.7071 -0.7071 0.7071 -0.7071 286.2939 937.5787)" style="fill:#009245;" width="32.013" height="32.013"></rect> </g> <circle style="fill:#FF1D25;" cx="296.979" cy="232.044" r="16.007"></circle> <path d="M103.855,207.842c-13.135,0-23.82-10.685-23.82-23.82c0-13.135,10.685-23.82,23.82-23.82s23.82,10.685,23.82,23.82 C127.675,197.156,116.99,207.842,103.855,207.842z M103.855,175.828c-4.518,0-8.194,3.675-8.194,8.194 c0,4.518,3.675,8.194,8.194,8.194c4.518,0,8.194-3.675,8.194-8.194C112.048,179.504,108.373,175.828,103.855,175.828z"></path> <path d="M391.98,239.856c-13.134,0-23.819-10.685-23.819-23.82c0-13.135,10.685-23.82,23.819-23.82 c13.135,0,23.82,10.685,23.82,23.82C415.8,229.17,405.115,239.856,391.98,239.856z M391.98,207.842 c-4.517,0-8.193,3.675-8.193,8.194c0,4.518,3.675,8.194,8.193,8.194c4.518,0,8.194-3.675,8.194-8.194 C400.174,211.517,396.498,207.842,391.98,207.842z"></path> <path d="M319.949,367.912c-13.135,0-23.82-10.685-23.82-23.82s10.685-23.82,23.82-23.82c13.135,0,23.82,10.685,23.82,23.82 S333.085,367.912,319.949,367.912z M319.949,335.898c-4.518,0-8.194,3.675-8.194,8.194c0,4.518,3.675,8.194,8.194,8.194 c4.518,0,8.194-3.675,8.194-8.194C328.142,339.573,324.467,335.898,319.949,335.898z"></path> <path d="M223.908,439.943c-13.135,0-23.82-10.685-23.82-23.82s10.685-23.82,23.82-23.82c13.135,0,23.82,10.685,23.82,23.82 S237.042,439.943,223.908,439.943z M223.908,407.929c-4.518,0-8.194,3.675-8.194,8.194s3.675,8.194,8.194,8.194 s8.194-3.675,8.194-8.194S228.426,407.929,223.908,407.929z"></path> <path d="M167.883,351.905c-13.135,0-23.82-10.685-23.82-23.82s10.686-23.82,23.82-23.82c13.134,0,23.819,10.685,23.819,23.82 S181.018,351.905,167.883,351.905z M167.883,319.891c-4.518,0-8.194,3.675-8.194,8.194c0,4.518,3.675,8.194,8.194,8.194 c4.517,0,8.193-3.675,8.193-8.194C176.077,323.566,172.4,319.891,167.883,319.891z"></path> <g> <polygon style="fill:#FFFFFF;" points="191.893,208.764 175.287,200.461 154.347,207.441 149.405,192.616 176.485,183.589 191.893,191.293 204.406,185.036 211.395,199.014 "></polygon> <polygon style="fill:#FFFFFF;" points="239.914,376.838 223.309,368.534 202.368,375.514 197.426,360.689 224.507,351.663 239.914,359.366 252.427,353.11 259.417,367.087 "></polygon> <polygon style="fill:#FFFFFF;" points="383.976,320.813 367.371,312.51 346.431,319.49 341.489,304.664 368.569,295.637 383.976,303.341 396.489,297.086 403.478,311.062 "></polygon> </g> <path d="M166.51,179.065l-33.687-33.687l33.687-33.687l33.687,33.687L166.51,179.065z M154.922,145.378l11.588,11.588l11.588-11.588 L166.51,133.79L154.922,145.378z"></path> <path d="M334.583,200.329l-33.687-33.687l33.687-33.687l33.687,33.687L334.583,200.329z M322.995,166.642l11.588,11.588 l11.588-11.588l-11.588-11.588L322.995,166.642z"></path> <path d="M337.33,443.179l-33.687-33.687l33.687-33.687l33.687,33.687L337.33,443.179z M325.742,409.492l11.588,11.588l11.588-11.588 l-11.588-11.588L325.742,409.492z"></path> <rect x="120.335" y="104.312" width="15.627" height="15.627"></rect> <rect x="199.51" y="111.605" width="16.668" height="15.627"></rect> <path d="M231.911,0.132c-61.946,0-120.183,24.123-163.986,67.925C24.122,111.859,0,170.097,0,232.042v7.813h139.872 c2.312,0,4.191,1.88,4.191,4.192c0,10.928,8.891,19.819,19.818,19.819h8.004c10.927,0,19.818-8.89,19.818-19.819 c0-2.312,1.881-4.192,4.192-4.192h43.829V0.132H231.911z M224.097,15.898v16.411C119.978,36.272,36.396,120.154,32.195,224.23 H15.766C19.797,111.162,111.03,19.929,224.097,15.898z M184.08,71.973c0,4.518-3.675,8.194-8.194,8.194 c-4.517,0-8.193-3.675-8.193-8.194s3.675-8.194,8.193-8.194C180.404,63.779,184.08,67.455,184.08,71.973z M195.895,224.229 c-10.928,0-19.819,8.891-19.819,19.819c0,2.312-1.88,4.191-4.191,4.191h-8.004c-2.312,0-4.191-1.88-4.191-4.192 c0-10.928-8.89-19.819-19.818-19.819h-3.912v-7.408h-15.627v7.408H47.833c1.148-26.132,7.741-50.841,18.653-73.04h13.218v-15.627 h-4.573c18.65-30.172,45.706-54.568,77.795-69.914c-0.555,2.015-0.858,4.135-0.858,6.324c0,13.135,10.685,23.82,23.819,23.82 c13.135,0,23.82-10.685,23.82-23.82c0-7.948-3.916-14.993-9.916-19.323c11.096-2.616,22.567-4.213,34.307-4.704v176.282h-28.202 V224.229z"></path> <rect x="392.239" y="159.526" width="15.627" height="15.627"></rect> <rect x="335.983" y="247.036" width="15.627" height="15.627"></rect> <rect x="431.826" y="216.824" width="16.668" height="15.627"></rect> <rect x="303.688" y="295.999" width="16.668" height="15.627"></rect> <rect x="415.158" y="321.002" width="16.668" height="15.627"></rect> <rect x="375.57" y="335.586" width="16.668" height="15.627"></rect> <rect x="359.944" y="344.962" width="15.627" height="15.627"></rect> <rect x="303.688" y="440.806" width="16.668" height="15.627"></rect> <rect x="216.179" y="295.999" width="15.627" height="15.627"></rect> <rect x="247.432" y="376.216" width="16.668" height="15.627"></rect> <rect x="103.667" y="295.999" width="16.668" height="15.627"></rect> <path d="M280.246,48.053h-7.813v223.982H48.451v7.813c0,62.024,23.922,120.309,67.751,164.118 c43.807,43.787,101.843,67.901,163.809,67.901c61.955,0,120.206-24.128,164.021-67.893c43.83-43.78,67.967-102.024,67.967-163.96 C512,152.138,408.035,48.053,280.246,48.053z M272.432,287.662v33.337h-8.334v15.627h8.334v103.136h15.627V287.662h152.099v-15.627 h-71.882v-7.292h-16.668v7.292h-63.548v-17.912c2.758,1.118,5.767,1.74,8.921,1.74c13.135,0,23.82-10.685,23.82-23.82 s-10.685-23.82-23.82-23.82c-3.153,0-6.164,0.622-8.921,1.74v-82.734h7.292v-15.627h-7.292V95.99 c23.6,1.048,46.019,6.531,66.47,15.613h-10.215v15.627h15.627v-13.12c59.427,28.74,100.965,88.411,103.975,157.927h-15.424v15.627 h15.441c-1.279,31.745-10.625,61.448-26.028,87.116c-3.637-8.51-12.09-14.489-21.915-14.489c-13.135,0-23.82,10.685-23.82,23.82 c0,12.035,8.972,22.006,20.578,23.594c-31.775,33.14-75.772,54.46-124.689,56.596v-15.162h-15.627v15.185 c-2.794-0.113-5.572-0.289-8.334-0.526v-7.366h-16.668v5.167c-29.656-5.322-56.872-17.793-79.819-35.525l24.583-24.583 l-33.687-33.687l-24.567,24.567c-4.238-5.497-8.166-11.241-11.773-17.199h5.459v-15.627h-13.925 c-10.551-21.957-16.868-46.28-17.881-71.882h176.612V287.662z M288.786,232.042c0-4.518,3.675-8.194,8.194-8.194 c4.518,0,8.194,3.675,8.194,8.194s-3.675,8.194-8.194,8.194C292.462,240.236,288.786,236.56,288.786,232.042z M424.185,384.109 c0,4.518-3.675,8.194-8.194,8.194c-4.518,0-8.194-3.675-8.194-8.194s3.675-8.194,8.194-8.194 C420.509,375.916,424.185,379.591,424.185,384.109z M146.918,401.489l11.588-11.588l11.588,11.588l-11.588,11.588L146.918,401.489z M432.989,432.942c-39.02,38.975-90.318,61.214-145.175,63.144l-0.068-11.106l-15.627,0.096l0.068,11.009 c-54.857-1.937-106.146-24.185-145.152-63.172c-39.029-39.011-61.315-90.336-63.249-145.253h16.395 c3.846,107.039,91.965,192.451,199.75,192.451c110.224,0,199.795-89.75,199.795-199.974c0-107.435-85.103-195.405-191.667-199.786 V63.919c112.9,4.04,204.009,95.161,208.151,208.116h-7.088v15.627h7.106C494.342,342.569,472.065,393.911,432.989,432.942z"></path> <polygon style="fill:#FFFFFF;" points="456.009,264.788 439.402,256.485 418.462,263.465 413.52,248.641 440.601,239.614 456.009,247.318 468.52,241.061 475.51,255.038 "></polygon> </g>
                    </svg>
                  </a>
                  <label for="amount" class="sr-only">Choose quantity:</label>
                  <div class="flex items-center justify-between md:order-3 md:justify-end">
                    <div class="flex items-center">
                    </div>
                    <div class="text-end md:order-4 md:w-32">
                      <p class="text-base font-bold text-gray-900 dark:text-white">{{$order->CalculatePrice()}}</p>
                    </div>
                    <div class="text-end md:order-4 md:w-32">
                        <button type="submit"  class="text-base font-bold text-gray-900 dark:text-white hover:underline">
                          Cancel order
                        </button>
                    </div>
                  </div>
                  <div class="w-full min-w-0 flex-1 space-y-4 md:order-2 md:max-w-md">
                    <a id="orderModalButton" data-modal-target="{{$order->id}}modal" data-modal-toggle="{{$order->id}}modal"class="text-base font-medium text-gray-900 hover:underline dark:text-white">{{$order->id}}</a>
                  </div>
                </div>
              </form>
              @include('includes/ordermodal', [ 'order' => $order])
            @endforeach

          </div>
        </div>
      </div>
    </div>
  </div>
</section>
<!-- Modal toggle -->
<!-- Main modal -->
         {{-- <div class="hidden xl:mt-8 xl:block">
          <h3 class="text-2xl font-semibold text-gray-900 dark:text-white">People also bought</h3>
          <div class="mt-6 grid grid-cols-3 gap-4 sm:mt-8">
            <div class="space-y-6 overflow-hidden rounded-lg border border-gray-200 bg-white p-6 shadow-sm dark:border-gray-700 dark:bg-gray-800">
              <a href="#" class="overflow-hidden rounded">
                <img class="mx-auto h-44 w-44 dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/imac-front.svg" alt="imac image" />
                <img class="mx-auto hidden h-44 w-44 dark:block" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/imac-front-dark.svg" alt="imac image" />
              </a>
              <div>
                <a href="#" class="text-lg font-semibold leading-tight text-gray-900 hover:underline dark:text-white">iMac 27”</a>
                <p class="mt-2 text-base font-normal text-gray-500 dark:text-gray-400">This generation has some improvements, including a longer continuous battery life.</p>
              </div>
              <div>
                <p class="text-lg font-bold text-gray-900 dark:text-white">
                  <span class="line-through"> $399,99 </span>
                </p>
                <p class="text-lg font-bold leading-tight text-red-600 dark:text-red-500">$299</p>
              </div>
              <div class="mt-6 flex items-center gap-2.5">
                <button data-tooltip-target="favourites-tooltip-1" type="button" class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white p-2.5 text-sm font-medium text-gray-900 hover:bg-gray-100 hover:text-primary-700 focus:z-10 focus:outline-none focus:ring-4 focus:ring-gray-100 dark:border-gray-600 dark:bg-gray-800 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white dark:focus:ring-gray-700">
                  <svg class="h-5 w-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 6C6.5 1 1 8 5.8 13l6.2 7 6.2-7C23 8 17.5 1 12 6Z"></path>
                  </svg>
                </button>
                <div id="favourites-tooltip-1" role="tooltip" class="tooltip invisible absolute z-10 inline-block rounded-lg bg-gray-900 px-3 py-2 text-sm font-medium text-white opacity-0 shadow-sm transition-opacity duration-300 dark:bg-gray-700">
                  Add to favourites
                  <div class="tooltip-arrow" data-popper-arrow></div>
                </div>
                <button type="button" class="inline-flex w-full items-center justify-center rounded-lg bg-primary-700 px-5 py-2.5 text-sm font-medium  text-white hover:bg-primary-800 focus:outline-none focus:ring-4 focus:ring-primary-300 dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800">
                  <svg class="-ms-2 me-2 h-5 w-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 4h1.5L9 16m0 0h8m-8 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4Zm8 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4Zm-8.5-3h9.25L19 7h-1M8 7h-.688M13 5v4m-2-2h4" />
                  </svg>
                  Add to cart
                </button>
              </div>
            </div>
            <div class="space-y-6 overflow-hidden rounded-lg border border-gray-200 bg-white p-6 shadow-sm dark:border-gray-700 dark:bg-gray-800">
              <a href="#" class="overflow-hidden rounded">
                <img class="mx-auto h-44 w-44 dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/ps5-light.svg" alt="imac image" />
                <img class="mx-auto hidden h-44 w-44 dark:block" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/ps5-dark.svg" alt="imac image" />
              </a>
              <div>
                <a href="#" class="text-lg font-semibold leading-tight text-gray-900 hover:underline dark:text-white">Playstation 5</a>
                <p class="mt-2 text-base font-normal text-gray-500 dark:text-gray-400">This generation has some improvements, including a longer continuous battery life.</p>
              </div>
              <div>
                <p class="text-lg font-bold text-gray-900 dark:text-white">
                  <span class="line-through"> $799,99 </span>
                </p>
                <p class="text-lg font-bold leading-tight text-red-600 dark:text-red-500">$499</p>
              </div>
              <div class="mt-6 flex items-center gap-2.5">
                <button data-tooltip-target="favourites-tooltip-2" type="button" class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white p-2.5 text-sm font-medium text-gray-900 hover:bg-gray-100 hover:text-primary-700 focus:z-10 focus:outline-none focus:ring-4 focus:ring-gray-100 dark:border-gray-600 dark:bg-gray-800 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white dark:focus:ring-gray-700">
                  <svg class="h-5 w-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 6C6.5 1 1 8 5.8 13l6.2 7 6.2-7C23 8 17.5 1 12 6Z"></path>
                  </svg>
                </button>
                <div id="favourites-tooltip-2" role="tooltip" class="tooltip invisible absolute z-10 inline-block rounded-lg bg-gray-900 px-3 py-2 text-sm font-medium text-white opacity-0 shadow-sm transition-opacity duration-300 dark:bg-gray-700">
                  Add to favourites
                  <div class="tooltip-arrow" data-popper-arrow></div>
                </div>
                <button type="button" class="inline-flex w-full items-center justify-center rounded-lg bg-primary-700 px-5 py-2.5 text-sm font-medium  text-white hover:bg-primary-800 focus:outline-none focus:ring-4 focus:ring-primary-300 dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800">
                  <svg class="-ms-2 me-2 h-5 w-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 4h1.5L9 16m0 0h8m-8 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4Zm8 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4Zm-8.5-3h9.25L19 7h-1M8 7h-.688M13 5v4m-2-2h4" />
                  </svg>
                  Add to cart
                </button>
              </div>
            </div>
            <div class="space-y-6 overflow-hidden rounded-lg border border-gray-200 bg-white p-6 shadow-sm dark:border-gray-700 dark:bg-gray-800">
              <a href="#" class="overflow-hidden rounded">
                <img class="mx-auto h-44 w-44 dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/apple-watch-light.svg" alt="imac image" />
                <img class="mx-auto hidden h-44 w-44 dark:block" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/apple-watch-dark.svg" alt="imac image" />
              </a>
              <div>
                <a href="#" class="text-lg font-semibold leading-tight text-gray-900 hover:underline dark:text-white">Apple Watch Series 8</a>
                <p class="mt-2 text-base font-normal text-gray-500 dark:text-gray-400">This generation has some improvements, including a longer continuous battery life.</p>
              </div>
              <div>
                <p class="text-lg font-bold text-gray-900 dark:text-white">
                  <span class="line-through"> $1799,99 </span>
                </p>
                <p class="text-lg font-bold leading-tight text-red-600 dark:text-red-500">$1199</p>
              </div>
              <div class="mt-6 flex items-center gap-2.5">
                <button data-tooltip-target="favourites-tooltip-3" type="button" class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white p-2.5 text-sm font-medium text-gray-900 hover:bg-gray-100 hover:text-primary-700 focus:z-10 focus:outline-none focus:ring-4 focus:ring-gray-100 dark:border-gray-600 dark:bg-gray-800 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white dark:focus:ring-gray-700">
                  <svg class="h-5 w-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 6C6.5 1 1 8 5.8 13l6.2 7 6.2-7C23 8 17.5 1 12 6Z"></path>
                  </svg>
                </button>
                <div id="favourites-tooltip-3" role="tooltip" class="tooltip invisible absolute z-10 inline-block rounded-lg bg-gray-900 px-3 py-2 text-sm font-medium text-white opacity-0 shadow-sm transition-opacity duration-300 dark:bg-gray-700">
                  Add to favourites
                  <div class="tooltip-arrow" data-popper-arrow></div>
                </div>

                <button type="button" class="inline-flex w-full items-center justify-center rounded-lg bg-primary-700 px-5 py-2.5 text-sm font-medium  text-white hover:bg-primary-800 focus:outline-none focus:ring-4 focus:ring-primary-300 dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800">
                  <svg class="-ms-2 me-2 h-5 w-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 4h1.5L9 16m0 0h8m-8 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4Zm8 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4Zm-8.5-3h9.25L19 7h-1M8 7h-.688M13 5v4m-2-2h4" />
                  </svg>
                  Add to cart
                </button>
              </div>
            </div>
          </div>
        </div>  --}}