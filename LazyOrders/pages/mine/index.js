// page/component/new-pages/user/user.js
const app = getApp()

Page({
  data: {
    userInfo: {},
    orders: [],
    pages: [{
      page: 'userInfo',
      text: '基本信息'
    }, {
      page: 'address',
      text: '收货地址'
    }, {
      page: 'orders',
      text: '我的订单'
    }],
    hasAddress: false,
    address: {}
  },
  
  onLoad() {
    
  },

  onShow() {
    var self = this;
    wx.getUserInfo({
      success: function (res) {
        self.setData({
          userInfo: res.userInfo
        });
      }
    })
  },
  /**
   * 发起支付请求
   */
  payOrders() {
    wx.requestPayment({
      timeStamp: 'String1',
      nonceStr: 'String2',
      package: 'String3',
      signType: 'MD5',
      paySign: 'String4',
      success: function(res) {
        console.log(res)
      },
      fail: function(res) {
        wx.showModal({
          title: '支付提示',
          content: '<text>',
          showCancel: false
        })
      }
    })
  },
})