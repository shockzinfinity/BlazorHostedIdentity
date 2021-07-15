export function initialize(lastItemIndicator, componentInstance) {
  const options = {
    root: findClosetScrollContainer(lastItemIndicator),
    rootMargin: '0px',
    threshold: 0,
  };

  const observer = new IntersectionObserver(async (entries) => {
    // when the lastItemIndicator element is visible => invoke the C# method 'LoadMoreItems'
    for (const entry of entries) {
      if (entry.isIntersecting) {
        await componentInstance.invokeMethodAsync("LoadMoreItems");
      }
    }
  }, options);

  observer.observe(lastItemIndicator);

  // allow to cleanup resources when the razor component is removed from th page
  return {
    dispose: () => infiniteScrollingDispose(observer),
    onNewItems: () => {
      observer.unobserve(lastItemIndicator);
      observer.observe(lastItemIndicator);
    }
  };
}

function infiniteScrollingDispose(observer) {
  observer.disconnect();
}

// find the parent element with a vertical scrollbar
// this container should be use as the root for the IntersectionObserver
function findClosetScrollContainer(element) {
  while (element) {
    const style = getComputedStyle(element);
    if (style.overflowY !== 'visible') {
      return element;
    }
    element = element.parentElement;
  }

  return null;
}