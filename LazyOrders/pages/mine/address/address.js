Page({
  data: {
    addressInfo: null,
    hasAddress: false
  },

  onShow() {
    const self = this;
    wx.getStorage({
      key: 'address',
      success(res) {
        self.setData({
          addressInfo: res.data,
          hasAddress: true
        })
      }
    });
  },

  chooseAddress() {
    const self = this;
    wx.chooseAddress({
      success: (res) => {
        self.setData({
          addressInfo: res,
          hasAddress: true
        });
        wx.setStorage({
          key: 'address',
          data: self.data.addressInfo,
        });

      },
      fail: function(err) {
        console.log(err)
      }
    })
  },
  chooseAddressed() {
    wx.navigateBack({
      delta: 1
    })
  }
})