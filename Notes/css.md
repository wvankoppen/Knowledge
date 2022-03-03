# CSS notes
[Basics of CSS layout](https://courses.thecssworkshop.com/p/css-layout)
- Inline level boxes are like words in a sentence
- Block level elements take all available width
- Inline elements can have padding/margin, but do not push other elements away
    - If you need to push other elements away, use inline-block
- Flex on container element makes it a block element, use inline-flex for inline 
- Content, border, margin box
    - Size is size of content (default)
  - Can be overridden with box-sizing: border-box (alternate box model). Can be set and inherited via html tag
- Writing-mode: vertical-rl to write from top to bottom
    - Width/height properties are not affected
    - Use block-size / inline-size for resp. width / height
    - Use *-block-start, *-block-stop,  *-inline-start, *-inline-stop for resp. *-top, *-bottom, *-left, *-right
- Elements participating in block or inline are "in flow". Don’t overlap each other, readable. To get out of flow:
    - Absolute positioning (position: absolute)
    - Floating (float: left )
- Clear flow: left, right or both. Deprecated way to create column layout, prefer Flexbox or CSS Grid
- Relative positioning: in flow (taken space is not moved), and able to push around with eg. left and top 
    - To get it out of flow, add a wrapper with absolute positioning
- Z-index: Stack over of elements. Only applicable for elements with a position property other than default value (static)!
- Fixed positioning: Use it for a navbar
    - Sticky positioning: Sticks after scrolling
- Display: flow-root (on wrapper) 
    - Could also be display: auto. But this could also create scrollbars!
    - The new way of creating a blockflowcontext (old way is clearfix)
- Collapsing margins: 
    - the highest margin wins and eats the lower margin
    - Empty elements cannot have margin, solution: add something in it (eg padding)
    - Border or padding stops margin from collapsing (outline does not)
    - Floating or absolute elements margins never collapse!
- Intrinsic vs. extrinsic dimensions
    - Intrinsic: dimension depends on its own content: min-content, max-content, 400px, fit-content(400px)
    - Extrinsic: dimension depends on the containing box: 20%, 


[Browser Compatibility](https://courses.thecssworkshop.com/p/browser-compatibility)
- Feature queries: @supports(display:grid) { ... }
- Media queries
- Vendor prefixes:
  - -webkit- (Chrome, Safari, newer versions of Opera, almost all iOS browsers including Firefox for iOS; basically, any WebKit based browser)
  - -moz- (Firefox)
  - -o- (old pre-WebKit versions of Opera)
  - -ms- (Internet Explorer and Microsoft Edge)

[Flexbox](https://courses.thecssworkshop.com/p/flexbox)
- 1 dimensional layout method (use CSS Grid for 2d)
- flex-direction: row means this is the main axis (column is cross axis) 
- Respects writing-mode (hence start/end instead of left/right) 
- Aligning on the: 
  - main axis use: justify-content (on container) (no individual item property, but you can use margin-left:auto that consumes all available space) 
  - cross axis use: align-items (on container) or align-self (on individual item)
